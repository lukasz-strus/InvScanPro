using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Helpers;
using InvScanPro.Models;
using InvScanPro.Services;
using InvScanPro.Views;

namespace InvScanPro.ViewModels;

public partial class DateViewModel : ObservableObject
{
    [ObservableProperty]
    DateTime date;

    private readonly ICsvFileService _csvFileService;
    private readonly ICacheService _cacheService;

    public DateViewModel(ICsvFileService csvFileService, ICacheService cacheService)
    {
        _csvFileService = csvFileService;
        _cacheService = cacheService;

        Date = CacheHelper.GetDateFromCache(_cacheService);
    }

    [RelayCommand]
    async Task NavigateToLocationPage()
    {
        var inventory = new Inventory()
        {
            Date = Date
        };

        var navigationParameter = new Dictionary<string, object>
        {
            { "Inventory", inventory }
        };

        await Shell.Current.GoToAsync($"{nameof(LocationPage)}", navigationParameter);
    }

    [RelayCommand]
    async Task LoadFile()
    {
        var inventoryItems = await _csvFileService.LoadCsvFileAsync();

        _cacheService.SetInventoryItems(inventoryItems);

        Date = CacheHelper.GetDateFromCache(_cacheService);
    }

}
