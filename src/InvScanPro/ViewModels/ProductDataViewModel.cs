using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Models;

namespace InvScanPro.ViewModels;

[QueryProperty(nameof(Inventory), "Inventory")]
public partial class ProductDataViewModel : ObservableObject
{
    [ObservableProperty] private Inventory? inventory;

    [RelayCommand]
    private async Task Back()
    {
        //TODO create back mechanism
    }

    [RelayCommand]
    private async Task Previous()
    {
        //TODO create previous mechanism
    }

    [RelayCommand]
    private async Task Next()
    {
        //TODO create next mechanism
    }
}
