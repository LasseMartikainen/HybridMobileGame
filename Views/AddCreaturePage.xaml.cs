using HybridMobileGame.ViewModels;

namespace HybridMobileGame.Views;

public partial class AddCreaturePage : ContentPage
{
    string enteredName;
    string imageFilePath;
    int idNumber;
    Color color;

    //This is for reading the color from ColorPickerView
    public static readonly BindableProperty SelectedColorProperty =
        BindableProperty.Create(nameof(SelectedColor), typeof(Color), typeof(AddCreaturePage), default(Color));
  
    //Also this is needed for reading the color
    public Color SelectedColor
    {
        get => (Color)GetValue(SelectedColorProperty);
        set => SetValue(SelectedColorProperty, value);
    }

    public AddCreaturePage()
    {
        InitializeComponent();
        CreateIdNumber();
        BindingContext = this;
    }

    private void CreateIdNumber()
    {
        idNumber = App.MainViewModel.Creatures.Count + 1;
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
        color = SelectedColor;
        Models.Creature newCreature = new Models.Creature(idNumber, enteredName, imageFilePath, color);
        App.MainViewModel.AddCreature(new ViewModels.CreatureViewModel(newCreature));
        await Navigation.PopAsync();
    }

    private async void Photo_Button_Clicked(object sender, EventArgs e)
    {
        //Check that device support is there.
        if (MediaPicker.Default.IsCaptureSupported)
        {
            //Launch the camera and save result.
            FileResult image = await MediaPicker.Default.CapturePhotoAsync();

            if (image != null)
            {
                //Get the images file path
                imageFilePath = Path.Combine(FileSystem.AppDataDirectory, image.FileName);

                //Save the photo.
                using Stream sourceStream = await image.OpenReadAsync();
                using (FileStream localFileStream = File.OpenWrite(imageFilePath))
                {
                    await sourceStream.CopyToAsync(localFileStream);
                }

                PhotoImage.Source = ImageSource.FromFile(imageFilePath);
            }
        }
    }

}