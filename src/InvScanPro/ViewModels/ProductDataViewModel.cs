using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Models;

namespace InvScanPro.ViewModels;

[QueryProperty(nameof(Inventory), "Inventory")]
public partial class ProductDataViewModel : ObservableObject
{
    [ObservableProperty]
    Inventory? inventory;

    [RelayCommand]
    async Task Back()
    {
        //TODO create back mechanism
    }

    [RelayCommand]
    async Task Previous()
    {
        //TODO create previous mechanism
    }

    [RelayCommand]
    async Task Next()
    {
        //TODO create next mechanism
    }
}
