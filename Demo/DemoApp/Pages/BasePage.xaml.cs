namespace DemoApp.Pages;
public partial class BasePage : ContentPage
{
	public IList<IView> BasePageContent => BaseContent.Children;
	public BasePage()
	{
		InitializeComponent();
	}
}