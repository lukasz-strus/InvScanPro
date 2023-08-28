using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Models;

namespace InvScanPro.ViewModels;

public partial class DateViewModel : ObservableObject
{
    [ObservableProperty]
    DateTime date = DateTime.Now; // TODO get date from file

    [RelayCommand]
    async Task NavigateToLocationPage()
    {
        var inventory = new Inventory()
        {
            Date = Date
        };

        var navigationParameter = new Dictionary<string, object>
        {
            { "Inventory", inventory }
        };

        await Shell.Current.GoToAsync($"{nameof(LocationPage)}", navigationParameter);
    }

    [RelayCommand]
    async Task LoadFile()
    {
        //TODO create load file mechanism
    }
}
