using DemoWASM.Models;
using DemoWASM.Pages.Exercices.GestionGamer;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;

namespace DemoWASM.Services {
    public class GameService(IJSRuntime JS, HttpClient Client) {

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
            return await Client.PostAsJsonAsync("Game", game);
        }
        public async Task<HttpResponseMessage> Update(GameDTO game) {
            await GetToken();
            return await Client.PutAsJsonAsync($"Game/{game.Id}", game);
        }

    }
}
