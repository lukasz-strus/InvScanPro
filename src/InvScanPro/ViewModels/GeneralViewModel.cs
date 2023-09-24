using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Helpers;
using InvScanPro.Models;
using InvScanPro.Services;
using InvScanPro.Views;

namespace InvScanPro.ViewModels;

[QueryProperty(nameof(Inventory), "Inventory")]
public partial class GeneralViewModel : BaseViewModel
{
    [ObservableProperty] private Inventory? _inventory;
    [ObservableProperty] private Product _scannedProduct = new();

    private readonly ICsvFileService _csvFileService;

    public GeneralViewModel(
        IStorageService storageService, 
        ICsvFileService csvFileService) : base(storageService)
    {
        _csvFileService = csvFileService;
        SetCaption("Label_0016");
    }

    [RelayCommand]
    private async Task LoadFile()
    {
        if (!_storageService.IsInventoryItemsEmpty())
        {
            if (!ShouldRemoveExistingDatabase().Result) return;
        }

        var inventoryItems = await _csvFileService.LoadCsvFileAsync();

        _storageService.SetInventoryItems(inventoryItems);

        Inventory!.Date = CacheHelper.GetDateFromCache(_storageService);

        SetCaption("Label_0016");
    }

    [RelayCommand]
    private async Task SaveQuantity()
    {
        //TODO create save quantity mechanism
    }

    [RelayCommand]
    private async Task Search()
    {
        if (string.IsNullOrEmpty(ScannedProduct!.STNumber))
        {
            await ShowEmptySTNumberError();
            return;
        };

        if (_storageService.IsInventoryItemsEmpty())
        {
            await ShowEmptyInventoryItemsError();
            return;
        }

        var inventoryItem = _storageService.GetInventoryItem(ScannedProduct!.STNumber);

        if (inventoryItem is null)
        {
            var result = await ShouldAddNewItem();
            if (!result) return;

            await NavigateToInventoryItemCreator();
            return;
        }

        SetScannedProduct(inventoryItem);
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

    private static async Task<bool> ShouldRemoveExistingDatabase()
        => await DisplayHelper.DisplayAlert("Label_0042", "Label_0043", "Label_0044", "Label_0045");

    private void SetScannedProduct(InventoryItem inventoryItem)
        => ScannedProduct = new()
        {
            STNumber = inventoryItem.Barcode,
            Quantity = inventoryItem.Count,
            Name = inventoryItem.Name,
            Info1 = inventoryItem.Info1,
            Info2 = inventoryItem.Info2,
            Info3 = inventoryItem.Info3
        };

    private async Task NavigateToInventoryItemCreator()
    {
        var navigationParameter = new Dictionary<string, object>
            {
                { "Product", ScannedProduct },
                { "Inventory", Inventory! }
            };

        await Shell.Current.GoToAsync($"{nameof(AddProductPage)}", navigationParameter);
    }

    private static async Task ShowEmptyInventoryItemsError()
        => await DisplayHelper.DisplayError("Label_0040", "Label_0047");

    private static async Task ShowEmptySTNumberError()
        => await DisplayHelper.DisplayError("Label_0040", "Label_0046");

    private static async Task<bool> ShouldAddNewItem()
        => await DisplayHelper.DisplayAlert("Label_0040", "Label_0048", "Label_0044", "Label_0045");

}
