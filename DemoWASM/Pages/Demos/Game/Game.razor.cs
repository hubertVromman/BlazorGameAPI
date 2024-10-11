namespace DemoWASM.Pages.Demos.Game {
    public partial class Game {

        public string ToShow { get; set; }
        public int ShowId { get; set; }

        public void ShowDetails(int id) {
            ToShow = "details";
            ShowId = id;
        }

        public void ShowUpdate(int id) {
            ToShow = "update";
            ShowId = id;
        }
    }
}
