using DemoApp.Pages;

namespace DemoApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new TestPage1());
	}
}