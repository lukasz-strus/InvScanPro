using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Helpers;
using InvScanPro.Models;
using InvScanPro.Services;
using InvScanPro.Views;

namespace InvScanPro.ViewModels;

[QueryProperty(nameof(Inventory), "Inventory")]
[QueryProperty(nameof(STNumber), "STNumber")]
public partial class GeneralViewModel : BaseViewModel
{
    private bool _navigateFromCreator;
    [ObservableProperty] private Inventory? _inventory;
    [ObservableProperty] private Product? _scannedProduct;
    [ObservableProperty] private string? _sTNumber;

    public GeneralViewModel(
        IStorageService storageService) : base(storageService)
    {
        SetCaption("Label_0016");
    }

    [RelayCommand]
    private void SaveQuantity()
    {
        var inventoryItem = StorageService.GetInventoryItem(ScannedProduct!.StNumber!);
        inventoryItem!.Count = ScannedProduct!.Quantity;
        SetScannedProduct(inventoryItem);
    }

    [RelayCommand]
    public async Task Search()
    {
        if (_navigateFromCreator)
        {
            _navigateFromCreator = false;
            return;
        }

        ScannedProduct = new Product
        {
            StNumber = STNumber
        };

        var inventoryItem = StorageService.GetInventoryItem(ScannedProduct!.StNumber!);

        if (inventoryItem is null)
        {
            _navigateFromCreator = true;
            var shouldAddNewItem = await ShouldAddNewItem(ScannedProduct.StNumber!);
            if (!shouldAddNewItem)
            {
                Shell.Current?.GoToAsync("..");
                return;
            }

            await NavigateToInventoryItemCreator();
            return;
        }

        SetScannedProduct(inventoryItem);

        var shouldAddItemToInventory = await ShouldAddItemToInventory(ScannedProduct.StNumber!);
        if (!shouldAddItemToInventory) return;

        inventoryItem.Count++;
        SetScannedProduct(inventoryItem);
    }

    private void SetScannedProduct(InventoryItem inventoryItem)
        => ScannedProduct = new Product
        {
            StNumber = inventoryItem.Barcode,
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
                { "Product", ScannedProduct! },
                { "Inventory", Inventory! }
            };

        await Shell.Current.GoToAsync($"{nameof(AddProductPage)}", navigationParameter);
    }

    private static async Task<bool> ShouldAddItemToInventory(string stNumber)
        => await DisplayHelper.DisplayAlert("Label_0042", "Label_0055", "Label_0044", "Label_0045", preMessage: stNumber);

    private static async Task<bool> ShouldAddNewItem(string stNumber)
        => await DisplayHelper.DisplayAlert("Label_0040", "Label_0048", "Label_0044", "Label_0045", preMessage: stNumber);

}
