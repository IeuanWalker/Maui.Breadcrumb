using App.Resources.Styles;

namespace App.Pages;

public partial class BasePage : ContentPage
{
	public IList<IView> BasePageContent => BaseContent.Children;

	public BasePage()
	{
		InitializeComponent();
	}
}
