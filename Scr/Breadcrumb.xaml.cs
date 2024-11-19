using System.ComponentModel;
using IeuanWalker.Maui.StateButton;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Devices;
using Microsoft.Maui.ApplicationModel;

namespace Breadcrumb;

public partial class Breadcrumb : ContentView
{
	#region Control properties

	// Separator
	public static readonly BindableProperty SeparatorProperty = BindableProperty.Create(nameof(Separator), typeof(ImageSource), typeof(Breadcrumb), new FontImageSource { Glyph = " / ", Color = Colors.Black, Size = 15, }, BindingMode.OneTime);

	public ImageSource Separator
	{
		get => (ImageSource)GetValue(SeparatorProperty);
		set => SetValue(SeparatorProperty, value);
	}

	// Separator height
	public static readonly BindableProperty SeparatorHeightProperty = BindableProperty.Create(nameof(SeparatorHeight), typeof(double), typeof(Breadcrumb), 15d, BindingMode.OneTime);

	public double SeparatorHeight
	{
		get => (double)GetValue(SeparatorHeightProperty);
		set => SetValue(SeparatorHeightProperty, value);
	}

	// FirstBreadCrumb
	public static readonly BindableProperty FirstBreadcrumbProperty = BindableProperty.Create(nameof(FirstBreadcrumb), typeof(ImageSource), typeof(Breadcrumb), null, BindingMode.OneTime);

	public ImageSource FirstBreadcrumb
	{
		get => (ImageSource)GetValue(FirstBreadcrumbProperty);
		set => SetValue(FirstBreadcrumbProperty, value);
	}

	// Scrollbar Visibility
	public static readonly BindableProperty ScrollBarVisibilityProperty = BindableProperty.Create(nameof(ScrollBarVisibility), typeof(ScrollBarVisibility), typeof(Breadcrumb), ScrollBarVisibility.Never, BindingMode.OneTime);

	public ScrollBarVisibility ScrollBarVisibility
	{
		get => (ScrollBarVisibility)GetValue(ScrollBarVisibilityProperty);
		set => SetValue(ScrollBarVisibilityProperty, value);
	}

	// FontSize
	public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(Breadcrumb), 15d, BindingMode.OneTime);

	[TypeConverter(typeof(FontSizeConverter))]
	public double FontSize
	{
		get => (double)GetValue(FontSizeProperty);
		set => SetValue(FontSizeProperty, value);
	}

	// Text Color
	public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(Breadcrumb), Colors.Black, BindingMode.OneTime);

	public Color TextColor
	{
		get => (Color)GetValue(TextColorProperty);
		set => SetValue(TextColorProperty, value);
	}

	// Font family
	public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(Breadcrumb), null, BindingMode.OneTime);
	public string FontFamily
	{
		get => (string)GetValue(FontFamilyProperty);
		set => SetValue(FontFamilyProperty, value);
	}


	// Corner radius
	public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(Breadcrumb), 10f, BindingMode.OneTime);

	public float CornerRadius
	{
		get => (float)GetValue(CornerRadiusProperty);
		set => SetValue(CornerRadiusProperty, value);
	}

	// Breadcrumb margin
	public static readonly BindableProperty BreadcrumbMarginProperty = BindableProperty.Create(nameof(BreadcrumbMargin), typeof(Thickness), typeof(Breadcrumb), new Thickness(0), BindingMode.OneTime);

	public Thickness BreadcrumbMargin
	{
		get => (Thickness)GetValue(BreadcrumbMarginProperty);
		set => SetValue(BreadcrumbMarginProperty, value);
	}

	// BreadcrumbBackgroundColor
	public static readonly BindableProperty BreadcrumbBackgroundColorProperty = BindableProperty.Create(nameof(BreadcrumbBackgroundColor), typeof(Color), typeof(Breadcrumb), Colors.Transparent, BindingMode.OneTime);

	public Color BreadcrumbBackgroundColor
	{
		get => (Color)GetValue(BreadcrumbBackgroundColorProperty);
		set => SetValue(BreadcrumbBackgroundColorProperty, value);
	}

	// LastBreadcrumbTextColor
	public static readonly BindableProperty LastBreadcrumbTextColorProperty = BindableProperty.Create(nameof(LastBreadcrumbTextColor), typeof(Color), typeof(Breadcrumb), Colors.Black, BindingMode.OneTime);

	public Color LastBreadcrumbTextColor
	{
		get => (Color)GetValue(LastBreadcrumbTextColorProperty);
		set => SetValue(LastBreadcrumbTextColorProperty, value);
	}

	// LastBreadcrumbCornerRadius
	public static readonly BindableProperty LastBreadcrumbCornerRadiusProperty = BindableProperty.Create(nameof(LastBreadcrumbCornerRadius), typeof(float), typeof(Breadcrumb), 10f, BindingMode.OneTime);

	public float LastBreadcrumbCornerRadius
	{
		get => (float)GetValue(LastBreadcrumbCornerRadiusProperty);
		set => SetValue(LastBreadcrumbCornerRadiusProperty, value);
	}

	// LastBreadcrumbBackgroundColor
	public static readonly BindableProperty LastBreadcrumbBackgroundColorProperty = BindableProperty.Create(nameof(LastBreadcrumbBackgroundColor), typeof(Color), typeof(Breadcrumb), Colors.Transparent, BindingMode.OneTime);

	public Color LastBreadcrumbBackgroundColor
	{
		get => (Color)GetValue(LastBreadcrumbBackgroundColorProperty);
		set => SetValue(LastBreadcrumbBackgroundColorProperty, value);
	}

	// AnimationSpeed
	public static readonly BindableProperty AnimationSpeedProperty = BindableProperty.Create(nameof(AnimationSpeed), typeof(uint), typeof(Breadcrumb), (uint)800, BindingMode.OneTime);

	public uint AnimationSpeed
	{
		get => (uint)GetValue(AnimationSpeedProperty);
		set => SetValue(AnimationSpeedProperty, value);
	}

	// IsNavigationEnabled
	public static readonly BindableProperty IsNavigationEnabledProperty = BindableProperty.Create(nameof(IsNavigationEnabled), typeof(bool), typeof(Breadcrumb), true, BindingMode.OneTime);

	public bool IsNavigationEnabled
	{
		get => (bool)GetValue(IsNavigationEnabledProperty);
		set => SetValue(IsNavigationEnabledProperty, value);
	}

	#endregion Control properties

	public Breadcrumb()
	{
		InitializeComponent();
	}

	async void BreadCrumbContainer_Loaded(object? sender, EventArgs e)
	{
		BreadCrumbContainer.Loaded -= BreadCrumbContainer_Loaded;

		// Get list of all pages in the NavigationStack that has a selectedPage title
		List<Page> pages = Navigation.NavigationStack.Select(x => x).Where(x => !string.IsNullOrEmpty(x?.Title)).ToList();

		// If any pages, make the control visible
		BreadCrumbsScrollView.IsVisible = pages.Count > 0;

		// Loop all pages
		foreach(Page page in pages)
		{
			// Create breadcrumb
			Border breadcrumb = BreadcrumbCreator(page, page.Equals(pages.LastOrDefault()), page.Equals(pages.FirstOrDefault()));
			if(!page.Equals(pages.LastOrDefault()))
			{
				// Add breadcrumb and separator to BreadCrumbContainer
				BreadCrumbContainer.Children.Add(breadcrumb);

				// Add separator
				Image separator = new()
				{
					HeightRequest = SeparatorHeight,
					Source = Separator,
					VerticalOptions = LayoutOptions.Center
				};
				AutomationProperties.SetIsInAccessibleTree(separator, false);
				BreadCrumbContainer.Children.Add(separator);

				continue;
			}

			if(BreadCrumbContainer.Children.Count > 0)
			{
				await BreadCrumbsScrollView.ScrollToAsync((View?)BreadCrumbContainer.Children.LastOrDefault(), ScrollToPosition.MakeVisible, false);
			}

			// Add ChildAdded event to trigger animation
			BreadCrumbContainer.ChildAdded += AnimatedStack_ChildAdded;

			// Move BreadCrumb of selectedPage to start the animation
			breadcrumb.TranslationX = Application.Current?.Windows[0].Page?.Width ?? 0;

			// Scroll to end of control
			await Task.Delay(10);

			// HACK: Remove once fixed - https://github.com/dotnet/maui/issues/9446
			if(BreadCrumbContainer.Width < BreadCrumbsScrollView.Width)
			{
				BreadCrumbContainer.WidthRequest = BreadCrumbsScrollView.Width;
			}

			await BreadCrumbsScrollView.ScrollToAsync(BreadCrumbContainer, ScrollToPosition.End, false);

			// Add breadcrumb to container
			BreadCrumbContainer.Children.Add(breadcrumb);

			// Scroll to last breadcrumb
			await BreadCrumbsScrollView.ScrollToAsync(BreadCrumbContainer, ScrollToPosition.End, AnimationSpeed != 0);
		}
	}

	/// <summary>
	/// Creates a new Breadcrumb object
	/// </summary>
	Border BreadcrumbCreator(Page page, bool isLast, bool isFirst)
	{
		// Create border control for the breadcrumb
		Border container = IsNavigationEnabled && !isLast ?
			new StateButton
			{
				ClickedCommand = new Command<Page>(async item => await GoBack(item).ConfigureAwait(false)),
				ClickedCommandParameter = page
			}
			: new Border();

		container.StrokeShape = new RoundRectangle
		{
			CornerRadius = isLast ? LastBreadcrumbCornerRadius : CornerRadius
		};
		container.Padding = 10;
		container.StrokeThickness = 0;
		container.Margin = BreadcrumbMargin;
		container.VerticalOptions = LayoutOptions.Center;
		container.SetBinding(BackgroundColorProperty, new Binding(isLast ? nameof(LastBreadcrumbBackgroundColor) : nameof(BreadcrumbBackgroundColor), source: new RelativeBindingSource(RelativeBindingSourceMode.FindAncestor, typeof(Breadcrumb))));

		SemanticProperties.SetDescription(container, page.Title);

		if(isFirst && FirstBreadcrumb is not null)
		{
			container.Content = new Image
			{
				Source = FirstBreadcrumb
			};
		}
		else
		{
			Label breadcrumbText = new()
			{
				Text = page.Title,
				FontSize = FontSize,
				FontFamily = FontFamily
			};
			breadcrumbText.SetBinding(Label.TextColorProperty, new Binding(isLast ? nameof(LastBreadcrumbTextColor) : nameof(TextColor), source: new RelativeBindingSource(RelativeBindingSourceMode.FindAncestor, typeof(Breadcrumb))));
			AutomationProperties.SetIsInAccessibleTree(breadcrumbText, false);

			container.Content = breadcrumbText;
		}

		return container;
	}

	/// <summary>
	/// Animates item added to stack
	/// </summary>
	async void AnimatedStack_ChildAdded(object? sender, ElementEventArgs e)
	{
		// iOS scroll to end fix
		if(DeviceInfo.Platform.Equals(DevicePlatform.iOS))
		{
			await BreadCrumbsScrollView.ScrollToAsync((View?)BreadCrumbContainer.Children.LastOrDefault(), ScrollToPosition.MakeVisible, false);
		}

		Animation lastBreadcrumbAnimation = new()
		{
			{ 0, 1, new Animation(_ => ((View)BreadCrumbContainer.Children[^1]).TranslationX = _, Application.Current?.Windows[0].Page?.Width ?? 0, 0, Easing.Linear) }
		};

		Point point = BreadCrumbsScrollView.GetScrollPositionForElement((View)BreadCrumbContainer.Children[^1], ScrollToPosition.End);
		lastBreadcrumbAnimation.Add(0, 1, new Animation(_ => BreadCrumbsScrollView.ScrollToAsync((View?)BreadCrumbContainer.Children.LastOrDefault(), ScrollToPosition.MakeVisible, true), BreadCrumbsScrollView.X, point.X - 6));

		lastBreadcrumbAnimation.Commit(this, nameof(lastBreadcrumbAnimation), 16, AnimationSpeed);
	}

	/// <summary>
	/// Navigates the user back to chosen selectedPage in the Navigation stack
	/// </summary>
	async Task GoBack(Page selectedPage)
	{
		// Check if selectedPage is still in Navigation Stack
		if(Navigation.NavigationStack.All(x => x != selectedPage))
		{
			// PopToRoot triggered if selectedPage is missing from navigation stack
			await Navigation.PopToRootAsync();
			return;
		}

		// Get all pages after and including selectedPage
		List<Page> pages = Navigation.NavigationStack.SkipWhile(x => x != selectedPage).ToList();

		// Remove selectedPage
		pages.Remove(selectedPage);

		// Remove current page (this will be removed with a PopAsync after all other relevant pages are removed)
		pages = pages.Take(pages.Count - 1).ToList();

		// Remove all pages left in list (i.e. all pages after selectedPage, minus the current page)
		foreach(Page page in pages)
		{
			Navigation.RemovePage(page);
		}

		// Remove current page
		await Navigation.PopAsync();
	}
}