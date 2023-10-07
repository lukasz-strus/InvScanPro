using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Helpers;
using InvScanPro.Models;
using InvScanPro.Services;
using InvScanPro.Views;

namespace InvScanPro.ViewModels;

public partial class FilterViewModel : BaseViewModel
{
    [ObservableProperty] private Inventory _inventory;

    public FilterViewModel(IStorageService storageService) : base(storageService)
    {
        Inventory = new Inventory
        {
            Date = CacheHelper.GetDateFromCache(StorageService)
        };
    }

    [RelayCommand]
    private async Task Filter()
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Inventory", Inventory }
        };

        await Shell.Current.GoToAsync(nameof(ProductDataPage), navigationParameter);
    }

}
