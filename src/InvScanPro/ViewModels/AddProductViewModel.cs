using CommunityToolkit.Mvvm.ComponentModel;
using InvScanPro.Models;
using InvScanPro.Services;

namespace InvScanPro.ViewModels;

[QueryProperty(nameof(Product), "Product")]
public partial class AddProductViewModel : ObservableObject
{
    [ObservableProperty] private Product? _product;

    private readonly IStorageService _storageService;    

    public AddProductViewModel(IStorageService storageService)
    {
        _storageService = storageService;
    }
}
