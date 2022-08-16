namespace App.Pages;

public partial class BasePage : ContentPage
{
	public IList<IView> BasePageContent => BaseContent.Children;

	public BasePage()
	{
		InitializeComponent();
	}

	async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		await Navigation.PopToRootAsync();
	}
}
