using DemoWASM.Models;
using DemoWASM.Pages.Exercices.GestionGamer;
using DemoWASM.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;

namespace DemoWASM.Pages.Demos.Game {
    public partial class AddGame {

        [Inject]
        public GameService gameService { get; set; }

        public GameDTO GameDTO { get; set; } = new();

        public async Task SubmitForm() {
            await gameService.Create(GameDTO);
            GameDTO = new();
        }
    }
}
