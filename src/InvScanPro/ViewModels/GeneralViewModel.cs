using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Models;

namespace InvScanPro.ViewModels;

[QueryProperty(nameof(Inventory), "Inventory")]
public partial class GeneralViewModel : ObservableObject
{
    [ObservableProperty]
    Inventory? inventory;

    [ObservableProperty]
    Product? scannedProduct;

    [RelayCommand]
    async Task LoadFile()
    {
        //TODO create load file mechanism
    }

    [RelayCommand]
    async Task SaveQuantity()
    {
        //TODO create save quantity mechanism
    }

    [RelayCommand]
    async Task Search()
    {
        //TODO create search mechanism
    }

    [RelayCommand]
    async Task Back()
    {
        //Tdo create back mechanism
    }

    [RelayCommand]
    async Task Save()
    {
        //TODO create save mechanism
    }

    [RelayCommand]
    async Task Close()
    {
        //TODO create close mechanism
    }
}
