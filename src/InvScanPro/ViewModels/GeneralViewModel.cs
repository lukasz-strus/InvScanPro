using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Helpers;
using InvScanPro.Models;
using InvScanPro.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InvScanPro.ViewModels;

[QueryProperty(nameof(Inventory), "Inventory")]
public partial class GeneralViewModel : ObservableObject
{
    [ObservableProperty] private Inventory? _inventory;
    [ObservableProperty] private Product? _scannedProduct;

    private readonly IStorageService _storageService;
    private readonly ICsvFileService _csvFileService;

    public GeneralViewModel(
        IStorageService storageService, 
        ICsvFileService csvFileService)
    {
        _storageService = storageService;
        _csvFileService = csvFileService;
    }

    [RelayCommand]
    private async Task LoadFile()
    {
        if (!_storageService.IsInventoryItemsEmpty())
        {
            bool result = await DisplayHelper.DisplayAlert("Label_0042", "Label_0043", "Label_0044", "Label_0045");

            if (!result) return;
        }

        var inventoryItems = await _csvFileService.LoadCsvFileAsync();

        _storageService.SetInventoryItems(inventoryItems);

        Inventory!.Date = CacheHelper.GetDateFromCache(_storageService);
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
