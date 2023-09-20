using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Helpers;
using InvScanPro.Models;
using InvScanPro.Services;
using InvScanPro.Views;

namespace InvScanPro.ViewModels;

[QueryProperty(nameof(Inventory), "Inventory")]
public partial class LocationViewModel : ObservableObject
{
    [ObservableProperty] private Inventory? _inventory;
    [ObservableProperty] private string? _location;

    private readonly ICsvFileService _csvFileService;
    private readonly IStorageService _storageService;

    public LocationViewModel(
        ICsvFileService csvFileService,
        IStorageService storageService)
    {
        _csvFileService = csvFileService;
        _storageService = storageService;
    }

    [RelayCommand]
    private async Task NavigateToGeneralPage()
    {
        if (string.IsNullOrEmpty(Location))
        {
            await DisplayHelper.DisplayError("Label_0040", "Label_0041");
            return;
        }

        Inventory!.Location = Location;

        var navigationParameter = new Dictionary<string, object>
        {
            { "Inventory", Inventory }
        };

        await Shell.Current.GoToAsync($"{nameof(GeneralPage)}", navigationParameter);
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
}
