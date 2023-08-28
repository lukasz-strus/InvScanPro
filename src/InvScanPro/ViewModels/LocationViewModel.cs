using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Models;
using System.Globalization;

namespace InvScanPro.ViewModels;

[QueryProperty(nameof(Inventory), "Inventory")]
public partial class LocationViewModel : ObservableObject
{
    [ObservableProperty]
    Inventory inventory;

    [ObservableProperty]
    string location;

    [RelayCommand]
    async Task NavigateToGeneralPage()
    {
        Inventory.Location = Location;

        var navigationParameter = new Dictionary<string, object>
        {
            { "Inventory", Inventory }
        };

        await Shell.Current.GoToAsync($"{nameof(GeneralPage)}", navigationParameter);
    }

    [RelayCommand]
    async Task LoadFile()
    {
        //TODO create load file mechanism
    }
}
