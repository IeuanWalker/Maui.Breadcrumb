namespace App.Pages;

public partial class TestPage2 : BasePage
{
	public TestPage2()
	{
		InitializeComponent();
	}

	async void Button_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new TestPage3(), true);
	}
}