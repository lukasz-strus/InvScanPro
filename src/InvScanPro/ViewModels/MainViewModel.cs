using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Helpers;
using InvScanPro.Models;
using InvScanPro.Services;
using InvScanPro.Views;

namespace InvScanPro.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    private readonly ICsvFileService _csvFileService;

    public MainViewModel(IStorageService storageService, ICsvFileService csvFileService) : base(storageService)
    {
        _csvFileService = csvFileService;
    }

    [RelayCommand]
    private async Task NavigateToDataPage()
    {
        await Shell.Current.GoToAsync(nameof(DatePage));
    }

    [RelayCommand]
    private async Task NavigateToFilterPage()
    {
        var inventoryEmpty = StorageService.IsInventoryItemsEmpty();

        if (inventoryEmpty)
        {
            await DisplayHelper.DisplayToast("Label_0066");
            return;
        }

        await Shell.Current.GoToAsync(nameof(FilterPage));
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

        if(inventoryItems.Count == 0) return;

        StorageService.SetInventoryItems(inventoryItems);

        SetCaption("Label_0065");
    }

    [RelayCommand]
    private static async Task Close()
    {
        var shouldExit = await ShouldExit();

        if (shouldExit) Environment.Exit(0);
    }

    private static async Task<bool> ShouldExit()
        => await DisplayHelper.DisplayAlert("Label_0042", "Label_0064", "Label_0044", "Label_0045");

    private static async Task<bool> ShouldRemoveExistingDatabase()
        => await DisplayHelper.DisplayAlert("Label_0042", "Label_0043", "Label_0044", "Label_0045");
}
