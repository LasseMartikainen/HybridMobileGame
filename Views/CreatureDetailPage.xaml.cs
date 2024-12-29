namespace HybridMobileGame.Views;

public partial class CreatureDetailPage : ContentPage
{
	public CreatureDetailPage()
	{
		InitializeComponent();

		//Set the data source for data bindings.
		BindingContext = App.MainViewModel.SelectedCreature;
	}
}