namespace App.Pages;

public partial class TestPage3 : BasePage
{
	public TestPage3()
	{
		InitializeComponent();
	}

	async void Button_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new TestPage1(), true);
	}
}