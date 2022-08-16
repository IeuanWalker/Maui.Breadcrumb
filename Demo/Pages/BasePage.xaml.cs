using App.Resources.Styles;

namespace App.Pages;

public partial class BasePage : ContentPage
{
	public IList<IView> BasePageContent => BaseContent.Children;

	public BasePage()
	{
		InitializeComponent();

		ToolbarItem toolBarItem = new()
		{
			Text = "Light"
		};

		toolBarItem.Clicked += ThemeToggle_Clicked;
		ToolbarItems.Add(toolBarItem);

		TapGestureRecognizer tapGestureRecognizer = new();
		tapGestureRecognizer.Tapped += async (_, e) => await Navigation.PopToRootAsync();
		HomeButton.GestureRecognizers.Add(tapGestureRecognizer);
	}

	async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		await Navigation.PopToRootAsync();
	}

	void ThemeToggle_Clicked(object? sender, EventArgs e)
	{
		ToolbarItem? item = (ToolbarItem?)sender;

		if (item is null || Application.Current is null)
		{
			return;
		}

		switch (item.Text)
		{
			case nameof(Theme.Light):
				Application.Current.Resources = new DarkTheme();
				item.Text = nameof(Theme.Dark);
				break;

			default:
				Application.Current.Resources = new LightTheme();
				item.Text = nameof(Theme.Light);
				break;
		}
	}
}

public enum Theme
{
	Light,
	Dark
}