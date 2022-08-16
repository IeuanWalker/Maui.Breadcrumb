| :memo:        | This is a MAUI version of my [Xamarin nuget](https://github.com/IeuanWalker/Xamarin.Forms.Breadcrumb)      |
|---------------|:------------------------|

<table>
  <thead>
    <tr>
      <td align="left">
        :warning: WARNING 
      </td>
    </tr>
  </thead>

  <tbody>
    <tr>
      <td>
         NuGet is in preview at the moment. There are several reason its in preview at the moment -
        <ul>
          <li>There is a bug in MAUI preventing the StackLayout within the scrollview from filling the width, this means the breadcrumb doesnt animate in from outside the screen, more info here - https://github.com/dotnet/maui/issues/9446</li>
          <li>It's not fully accessible</li>
          <li>I havnt tested iOS yet</li>
        </ul>
      </td>
    </tr>
  </tbody>
</table>




# Maui.Breadcrumb 

This is a breadcrumb navigation control that is completely automatic and uses the Navigation stack to get the page titles to generate the breadcrumbs.

The animation for the control is based on this article - [A Cool Breadcrumbs Bar with Xamarin Forms Animations…](https://theconfuzedsourcecode.wordpress.com/2017/02/04/a-cool-breadcrumbs-bar-with-xamarin-forms-animations/)

Basic example             |  Production Example
:-------------------------:|:-------------------------:
![Example gif](/Example.gif)  |  ![Production Example gif](/ProdExample.gif)



## How to use it?
Install the [NuGet package](https://www.nuget.org/packages/Xamarin.Forms.Breadcrumb) into all of your projects 
```
Install-Package Xamarin.Forms.Breadcrumb
```

For iOS add the following to AppDelegate.cs > FinishedLaunching
```csharp
BreadcrumbButtonRenderer.Init();
```

To add to a page the first thing we need to do is tell our XAML page where it can find the Breadcrumb control, which is done by adding the following attribute to our ContentPage:

```xml
<ContentPage x:Class="DemoApp.Pages.BasePage"
             xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:breadcrumb="clr-namespace:Breadcrumb;assembly=Breadcrumb"
             xmlns:d="http://xamarin.com/schemas/2014/forms/design"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             mc:Ignorable="d">
    <ContentPage.Content>
        ...
    </ContentPage.Content>
</ContentPage>
```

Next up, just add the breadcrumb control onto that page and you're all set.

```xml
<breadcrumb:Breadcrumb Padding="15" VerticalOptions="Start" />
```

## What can I do with it?

| Property | What it does | Extra info |
|---|---|---- |
| ScrollBarVisibility | Sets the HorizontalScrollBarVisibility of the scrollview | More info here [ScrollBarVisibility](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.scrollbarvisibility?view=xamarin-forms). Default value is **ScrollBarVisibility.Never**
| FontSize | Sets the text font size for the breadcrumb | Default value is **15**. <br>Support [`NamedSize`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.namedsize?view=xamarin-forms) |
| TextColor | Sets the text color for the breadcrumb and seperator   | A `Color` object. <br> Default value is **black**. <br>*(doesnt include the last breadcrumb)* |
| CornerRadius | A `CornerRadius` object representing each individual corner's radius for each breadcrumb. <br> This property exposed from [PancakeView](https://github.com/sthewissen/Xamarin.Forms.PancakeView) | Uses the `CornerRadius` struct allowing you to specify individual corners. <br> Default value is **10**. <br> *(doesnt include the last breadcrumb)* |
| BreadcrumbMargin | A `Thickness` object used to define the spacing between the breadcrumb and separators | Uses the `Thickness` struct allowing you to specify left, top, right and bottom margin |
| BreadcrumbBackgroundColor | This is the background color for the individual breadcrumbs | A `Color` object. <br> Default value is **Transparent**. <br> *(doesnt include the last breadcrumb)* |
| LastBreadcrumbTextColor | Sets the text color for the last breadcrumb | A Color object. <br> Default value is **black**. |
| LastBreadcrumbCornerRadius | A `CornerRadius` object representing each individual corner's radius. <br> This is property exposed from [PancakeView](https://github.com/sthewissen/Xamarin.Forms.PancakeView) | Uses the `CornerRadius` struct allowing you to specify individual corners. <br> Default value is **10**. |
| LastBreadcrumbBackgroundColor | Sets the background color of the last breadcrumbs |  A Color object. <br> Default value is **Transparent**. |
| AnimationSpeed | Sets the speed of the animated breadcrumb | Default value is **800**. <br> Set to 0 to disable the animation. |
| IsNavigationEnabled | Used to remove the tab gesture from breadcrumbs | Default value is **True**|

### First breadcrumb customization
You are able to change the first breadcrumb to an Icon, embedded image or url image.
It implements the Xamarin.Forms ImageSource object.

```xml
<breadcrumb:Breadcrumb Padding="15" VerticalOptions="Start">
    <breadcrumb:Breadcrumb.FirstBreadCrumb>
        <FontImageSource FontFamily="{StaticResource FontAwesome}"
                            Glyph="{x:Static icons:IconFont.Home}"
                            Size="35"
                            Color="Red" />
    </breadcrumb:Breadcrumb.FirstBreadCrumb>
</breadcrumb:Breadcrumb>
```

### Separator customization 
You are able to change the separators to an Icon, embedded image or url image.
It implements the Xamarin.Forms ImageSource object.

Font - (FontAwesome)
```xml
<breadcrumb:Breadcrumb Padding="15" VerticalOptions="Start">
    <breadcrumb:Breadcrumb.Separator>
        <FontImageSource FontFamily="{StaticResource FontAwesome}"
                            Glyph="{x:Static icons:IconFont.ChevronRight}"
                            Size="15"
                            Color="Red" />
    </breadcrumb:Breadcrumb.Separator>
</breadcrumb:Breadcrumb>
```

Image - URL
```xml
<breadcrumb:Breadcrumb Padding="15" VerticalOptions="Start">
    <breadcrumb:Breadcrumb.Separator>
        <UriImageSource Uri="https://cdn.iconscout.com/icon/free/png-256/xamarin-4-599473.png" />
    </breadcrumb:Breadcrumb.Separator>
</breadcrumb:Breadcrumb>
```

Image - Embedded
```xml
<breadcrumb:Breadcrumb Padding="15" VerticalOptions="Start">
    <breadcrumb:Breadcrumb.Separator>
        <FileImageSource File="exampleImage.png" />
    </breadcrumb:Breadcrumb.Separator>
</breadcrumb:Breadcrumb>
```
