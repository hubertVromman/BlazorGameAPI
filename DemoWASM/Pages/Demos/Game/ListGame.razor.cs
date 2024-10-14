using DemoWASM.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using DemoWASM.Services;
using System.Text.Json;

namespace DemoWASM.Pages.Demos.Game {
    public partial class ListGame {
        [Inject]
        public GameService gameService { get; set; }

        public IEnumerable<GameDTO> GameList { get; set; } = new List<GameDTO>();

        [Parameter]
        public EventCallback<int> ShowDetailsParent { get; set; }

        [Parameter]
        public EventCallback<int> ShowUpdateParent { get; set; }

        public void ShowDetails(int id) {
            ShowDetailsParent.InvokeAsync(id);
        }

        public void ShowUpdate(int id) {
            ShowUpdateParent.InvokeAsync(id);
        }

        public async Task Delete(int id) {
            await gameService.Delete(id);
        }

        protected override async Task OnInitializedAsync() {
            gameService.DataChanged += HandleEvent;
            await LoadData();
        }

        public async Task LoadData() {
            GameList = await gameService.Get();
        }

        public async Task HandleEvent() {
            await LoadData();
            StateHasChanged();
        }
    }
}
