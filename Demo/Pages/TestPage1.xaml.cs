using App.Resources.Styles;

namespace App.Pages;

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

	//void ThemeToggle_Clicked(object sender, EventArgs e)
	//{
	//	if (ThemeToggle == null)
	//	{
	//		return;
	//	}

	//	switch (ThemeToggle.Text)
	//	{
	//		case nameof(Theme.Light):
	//			Application.Current.Resources = new DarkTheme();
	//			ThemeToggle.Text = nameof(Theme.Dark);
	//			break;

	//		default:
	//			Application.Current.Resources = new LightTheme();
	//			ThemeToggle.Text = nameof(Theme.Light);
	//			break;
	//	}
	//}

}

public enum Theme
{
	Light,
	Dark
}