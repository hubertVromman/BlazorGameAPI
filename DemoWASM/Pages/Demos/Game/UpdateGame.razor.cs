using DemoWASM.Models;
using DemoWASM.Services;
using Microsoft.AspNetCore.Components;

namespace DemoWASM.Pages.Demos.Game {
    public partial class UpdateGame {
        [Inject]
        public GameService gameService { get; set; }

        [Parameter]
        public int GameId { get; set; }

        public GameDTO GameToUpdate { get; set; } = new();

        private async Task LoadGame() {
            GameToUpdate = await gameService.Get(GameId);
        }

        protected async override Task OnInitializedAsync() {
            await LoadGame();
        }

        public async Task SubmitForm() {
            await gameService.Update(GameToUpdate);
            await LoadGame();
        }

        protected async override Task OnParametersSetAsync() {
            await LoadGame();
        }
    }
}
