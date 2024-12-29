namespace HybridMobileGame
{
    public partial class App : Application
    {
        public static ViewModels.CreatureListViewModel MainViewModel { get; private set; }
        public App()
        {
            InitializeComponent();

            //Setup the first page and navigation structure of the app.
            MainPage = new AppShell();

            //Setup the main ViewModel that manages data for the app.
            MainViewModel = new ViewModels.CreatureListViewModel();

            //Asynchronously populate the view with data.
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await MainViewModel.RefreshCreatures();
        }
    }
}
