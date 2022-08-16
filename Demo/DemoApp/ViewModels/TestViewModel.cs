using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace App.ViewModels;

[INotifyPropertyChanged]
public partial class TestViewModel
{
	[RelayCommand]
	static async Task Clicked()
	{
		await Alert("Clicked command", "Button clicked");
	}

	[RelayCommand]
	static async Task Pressed()
	{
		await Alert("Pressed command", "Button pressed");
	}

	[RelayCommand]
	static async Task Released()
	{
		await Alert("Released command", "Button released");
	}

	static async Task Alert(string title, string message)
	{
		Page? mainpage = Application.Current?.MainPage;
		if (mainpage is not null)
		{
			await mainpage.DisplayAlert(title, message, "OK");
		}
	}
}