using App.Resources.Styles;

namespace App.Pages;

public partial class BasePage : ContentPage
{
	public IList<IView> BasePageContent => BaseContent.Children;

	public BasePage()
	{
		InitializeComponent();
	}

	void ThemeToggle_Clicked(object sender, EventArgs e)
	{
		if (ThemeToggle == null)
		{
			return;
		}

		switch (ThemeToggle.Text)
		{
			case nameof(Theme.Light):
				Application.Current.Resources = new DarkTheme();
				ThemeToggle.Text = nameof(Theme.Dark);
				break;

			default:
				Application.Current.Resources = new LightTheme();
				ThemeToggle.Text = nameof(Theme.Light);
				break;
		}
	}
}
public enum Theme
{
	Light,
	Dark
}
