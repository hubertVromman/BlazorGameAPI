using DemoWASM.Models;
using DemoWASM.Pages.Exercices.GestionGamer;
using DemoWASM.Services;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;

namespace DemoWASM.Pages.Demos.Game {
    public partial class DetailsGame {

        [Inject]
        public GameService gameService { get; set; }

        //private int _gameId;

        [Parameter]
        public int GameId { get; set; }

        public GameDTO GameToShow { get; set; } = new();

        private async Task LoadGame() {
            GameToShow = await gameService.Get(GameId);
        }

        protected async override Task OnInitializedAsync() {
            await LoadGame();
        }

        protected async override Task OnParametersSetAsync() {
            await LoadGame();
        }
    }
}
