namespace HybridMobileGame.Views;

public partial class CreatureListPage : ContentPage
{
	public CreatureListPage()
	{
		InitializeComponent();
	}

	/// <summary>
	/// Handle the tapping of an item in the list
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		//Navigate to new page that is pushed to the navigation stack
		await Navigation.PushAsync(new Views.CreatureDetailPage());
	}

	/// <summary>
	/// Handle clicking of an item in the list
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private void MenuItem_Clicked(object sender, EventArgs e)
    {
		MenuItem menuItem = (MenuItem)sender;
		//Retrieve the item to be deleted through binding context.
		ViewModels.CreatureViewModel creature = (ViewModels.CreatureViewModel)menuItem.BindingContext;
		//Call the actual deleting method.
		App.MainViewModel.DeleteCreature(creature);
    }

    private async void Add_Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Views.AddCreaturePage());
    }

    private async void Save_Button_Clicked(object sender, EventArgs e)
    {
		await App.MainViewModel.SaveCreatures();
    }

    private async void Details_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.ProductDetailsPage());
    }
}