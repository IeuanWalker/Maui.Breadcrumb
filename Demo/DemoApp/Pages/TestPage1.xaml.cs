namespace DemoApp.Pages;
public partial class TestPage1 : BasePage
{
	public TestPage1()
	{
		InitializeComponent();
	}

	async void Button_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new TestPage2(), true);
	}
}