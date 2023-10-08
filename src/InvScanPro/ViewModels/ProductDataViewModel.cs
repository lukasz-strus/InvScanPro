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

    private readonly List<InventoryItem> _inventoryItems;

    public ProductDataViewModel(IStorageService storageService) : base(storageService)
    {
        SetCaption("Label_0037");

        _inventoryItems = StorageService.GetInventoryItems();
        var firstInventoryItem = _inventoryItems.FirstOrDefault();
        AssignToProduct(firstInventoryItem);
    }

    [RelayCommand]
    private async Task Previous()
    {
        //TODO create previous mechanism (REVERSE SKIP WHILE)
    }

    [RelayCommand]
    private void Next()
    {
        var nextInventoryItem = _inventoryItems
            .SkipWhile(i => i.Barcode != Product?.StNumber)
            .Skip(1)
            .FirstOrDefault();

        AssignToProduct(nextInventoryItem);
    }

    private void AssignToProduct(InventoryItem? inventoryItem)
    {
        if (inventoryItem != null)
        {
            Product = new Product()
            {
                StNumber = inventoryItem.Barcode,
                Name = inventoryItem.Name,
                Info1 = inventoryItem.Info1,
                Info2 = inventoryItem.Info2,
                Info3 = inventoryItem.Info3,
                Quantity = inventoryItem.Count,
            };
        }
    }
}
