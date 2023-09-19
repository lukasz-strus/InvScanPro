using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Models;

namespace InvScanPro.ViewModels;

[QueryProperty(nameof(Inventory), "Inventory")]
public partial class GeneralViewModel : ObservableObject
{
    [ObservableProperty] Inventory? inventory;

    [ObservableProperty] private Product? scannedProduct;

    [RelayCommand]
    private async Task LoadFile()
    {
        //TODO create load file mechanism
    }

    [RelayCommand]
    private async Task SaveQuantity()
    {
        //TODO create save quantity mechanism
    }

    [RelayCommand]
    private async Task Search()
    {
        //TODO create search mechanism
    }

    [RelayCommand]
    private async Task Back()
    {
        //Tdo create back mechanism
    }

    [RelayCommand]
    private async Task Save()
    {
        //TODO create save mechanism
    }

    [RelayCommand]
    private async Task Close()
    {
        //TODO create close mechanism
    }
}
