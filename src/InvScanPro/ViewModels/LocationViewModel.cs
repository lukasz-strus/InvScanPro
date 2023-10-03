using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Helpers;
using InvScanPro.Models;
using InvScanPro.Services;
using InvScanPro.Views;

namespace InvScanPro.ViewModels;

[QueryProperty(nameof(Inventory), "Inventory")]
public partial class LocationViewModel : BaseViewModel
{
    [ObservableProperty] private Inventory? _inventory;
    [ObservableProperty] private string? _location;

    private readonly ICsvFileService _csvFileService;

    public LocationViewModel(
        ICsvFileService csvFileService,
        IStorageService storageService) : base(storageService)
    {
        _csvFileService = csvFileService;
        SetCaption("Label_0014");
    }

    [RelayCommand]
    private async Task NavigateToGeneralPage()
    {
        if (string.IsNullOrEmpty(Location))
        {
            await ShowEmptyLocationError();
            return;
        }

        Inventory!.Location = Location;

        var navigationParameter = new Dictionary<string, object>
        {
            { "Inventory", Inventory }
        };

        await Shell.Current.GoToAsync($"{nameof(StartInventoryPage)}", navigationParameter);
    }



    [RelayCommand]
    private async Task LoadFile()
    {
        if (!StorageService.IsInventoryItemsEmpty())
        {
            var shouldRemoveExistingDatabase = await ShouldRemoveExistingDatabase();
            if (!shouldRemoveExistingDatabase) return;
        }

        var inventoryItems = await _csvFileService.LoadCsvFileAsync();

        StorageService.SetInventoryItems(inventoryItems);

        Inventory!.Date = CacheHelper.GetDateFromCache(StorageService);

        SetCaption("Label_0014");
    }
    private static async Task ShowEmptyLocationError()
        => await DisplayHelper.DisplayToast("Label_0041");

    private static async Task<bool> ShouldRemoveExistingDatabase()
        => await DisplayHelper.DisplayAlert("Label_0042", "Label_0043", "Label_0044", "Label_0045");
}
