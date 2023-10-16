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
    [ObservableProperty] private string? _listPosition;

    private List<InventoryItem>? _inventoryItems;

    public ProductDataViewModel(IStorageService storageService) : base(storageService)
    {
        SetCaption("Label_0037");
    }

    [RelayCommand]
    private void Init()
    {
        _inventoryItems = StorageService
            .GetInventoryItems()
            .Where(ItemIsInInventory)
            .ToList();

        var firstInventoryItem = _inventoryItems.FirstOrDefault();
        AssignToProduct(firstInventoryItem);
    }

    [RelayCommand]
    private void Previous()
    {
        var reversedInventoryItems = Enumerable.Reverse(_inventoryItems!);

        var previousInventoryItem = reversedInventoryItems
            .SkipWhile(i => i.Barcode != Product?.StNumber)
            .Skip(1)
            .FirstOrDefault();

        AssignToProduct(previousInventoryItem);
    }

    [RelayCommand]
    private void Next()
    {
        var nextInventoryItem = _inventoryItems?
            .SkipWhile(i => i.Barcode != Product?.StNumber)
            .Skip(1)
            .FirstOrDefault();

        AssignToProduct(nextInventoryItem);
    }

    private void AssignToProduct(InventoryItem? inventoryItem)
    {
        if (inventoryItem == null) return;

        Product = new Product()
        {
            StNumber = inventoryItem.Barcode,
            Name = inventoryItem.Name,
            Info1 = inventoryItem.Info1,
            Info2 = inventoryItem.Info2,
            Info3 = inventoryItem.Info3,
            Quantity = inventoryItem.Count,
        };

        var index = _inventoryItems?.IndexOf(inventoryItem);
        ListPosition = $"{index + 1}/{_inventoryItems?.Count}";
    }

    private bool ItemIsInInventory(InventoryItem inventory)
        => Inventory?.Location == inventory.Location
           && Inventory?.Date == inventory.Date;
}
