using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Models;
using InvScanPro.Services;

namespace InvScanPro.ViewModels;

[QueryProperty(nameof(Inventory), "Inventory")]
public partial class ProductDataViewModel : BaseViewModel
{
    [ObservableProperty] private Inventory? _inventory;
    [ObservableProperty] private Product? _product;

    private List<InventoryItem> _inventoryItems;

    public ProductDataViewModel(IStorageService storageService) : base(storageService)
    {
        SetCaption("Label_0037");

        _inventoryItems = StorageService.GetInventoryItems();
        var firstInventoryItem = _inventoryItems.FirstOrDefault();

        if (firstInventoryItem != null)
        {
            _product = new Product()
            {
                StNumber = firstInventoryItem.Barcode,
                Name = firstInventoryItem.Name,
                Info1 = firstInventoryItem.Info1,
                Info2 = firstInventoryItem.Info2,
                Info3 = firstInventoryItem.Info3,
                Quantity = firstInventoryItem.Count,
            };
        }
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
