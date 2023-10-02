using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Helpers;
using InvScanPro.Models;
using InvScanPro.Services;

namespace InvScanPro.ViewModels;

[QueryProperty(nameof(Product), "Product")]
[QueryProperty(nameof(Inventory), "Inventory")]
public partial class AddProductViewModel : ObservableObject
{
    [ObservableProperty] private Product? _product;
    [ObservableProperty] private Inventory? _inventory;

    private readonly IStorageService _storageService;    

    public AddProductViewModel(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [RelayCommand]
    private async Task Save()
    {
        var result = await DisplayHelper.DisplayAlert("Label_0042", "Label_0050", "Label_0044", "Label_0045");

        if (!result) return;        

        var items = _storageService.GetInventoryItems();

        var item = new InventoryItem()
        {
            Countingnum = items[0].Countingnum,
            Barcode = Product!.STNumber ?? "",
            Name = Product!.Name ?? "",
            Count = Product.Quantity,
            Info1 = Product!.Info1 ?? "",
            Info2 = Product!.Info2 ?? "",
            Info3 = Product!.Info3 ?? "",
            Location = Inventory!.Location ?? "",
            Date = Inventory!.Date
        };

        _storageService.AddInventoryItem(item);

        await DisplayHelper.DisplayToast("Label_0063", preMessage: item.Barcode);

        await Shell.Current.GoToAsync("..");
    }
}
