using DemoWASM.Models;
using DemoWASM.Pages.Exercices.GestionGamer;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;

namespace DemoWASM.Services {
    public class GameService(IJSRuntime JS, HttpClient Client) {

        public delegate Task AsyncEventHandler();
        public event AsyncEventHandler DataChanged;

        private async Task GetToken() {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<IEnumerable<GameDTO>> Get() {
            await GetToken();
            return await Client.GetFromJsonAsync<List<GameDTO>>("Game");
        }

        public async Task<GameDTO> Get(int id) {
            await GetToken();
            return await Client.GetFromJsonAsync<GameDTO>($"Game/{id}");
        }

        public async Task<HttpResponseMessage> Create(GameDTO game) {
            await GetToken();
            HttpResponseMessage message = await Client.PostAsJsonAsync("Game", game);
            await DataChanged?.Invoke();
            return message;
        }

        public async Task<HttpResponseMessage> Update(GameDTO game) {
            await GetToken();
            HttpResponseMessage message = await Client.PutAsJsonAsync($"Game/{game.Id}", game);
            await DataChanged?.Invoke();
            return message;
        }

        public async Task<HttpResponseMessage> Delete(int id) {
            await GetToken();
            HttpResponseMessage message = await Client.DeleteAsync($"Game/{id}");
            await DataChanged?.Invoke();
            return message;
        }
    }
}
