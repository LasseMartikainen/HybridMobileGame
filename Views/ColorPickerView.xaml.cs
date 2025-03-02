

namespace HybridMobileGame.Views;

public partial class ColorPickerView : ContentView
{
	public ColorPickerView()
	{
		InitializeComponent();
	}

    private void OnColorChanged(object sender, ValueChangedEventArgs e)
    {
		var red = (int)RedSlider.Value;
		var green = (int)GreenSlider.Value;
		var blue = (int)BlueSlider.Value;

		PreviewBox.Color = Color.FromRgb(red, green, blue);
		SelectedColor = Color.FromRgb(red, green, blue);
    }

    public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create(nameof(SelectedColor), typeof(Color), typeof(ColorPickerView), Colors.White);

	public Color SelectedColor
	{
		get => (Color)GetValue(SelectedColorProperty);
		set => SetValue(SelectedColorProperty, value);
	}
}