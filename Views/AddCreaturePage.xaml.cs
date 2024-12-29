namespace HybridMobileGame.Views;

public partial class AddCreaturePage : ContentPage
{
    string enteredName;

	public AddCreaturePage()
	{
		InitializeComponent();
	}

    private void entry_Completed(object sender, EventArgs e)
    {
        enteredName = ((Entry)sender).Text;
    }

    private void entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        enteredName = ((Entry)sender).Text;
    }

    private async void AddCreatureButton_Clicked(object sender, EventArgs e)
    {
        Models.Creature newCreature = new Models.Creature(99, enteredName, "dotnet_bot.png");
        App.MainViewModel.AddCreature(new ViewModels.CreatureViewModel(newCreature));
        await Navigation.PopAsync();
    }
}