using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Helpers;
using InvScanPro.Models;
using InvScanPro.Services;
using InvScanPro.Views;

namespace InvScanPro.ViewModels;

[QueryProperty(nameof(Inventory), "Inventory")]
public partial class StartInventoryViewModel : BaseViewModel
{
    [ObservableProperty] private Inventory? _inventory;
    [ObservableProperty] private string? _sTNumber;
    private readonly ICsvFileService _csvFileService;

    public StartInventoryViewModel(IStorageService storageService, ICsvFileService csvFileService) : base(storageService)
    {
        SetCaption("Label_0053");
        _csvFileService = csvFileService;
    }

    [RelayCommand]
    private async Task Scan()
    {
        var popup = new ScannerPage();
        STNumber = await Shell.Current.CurrentPage.ShowPopupAsync(popup) as string;
        SearchCommand.Execute(null);
    }

    [RelayCommand]
    private async Task Search()
    {
        if(string.IsNullOrEmpty(STNumber))
        {
            await ShowEmptyStNumberError();
            return;
        }

        if (StorageService.IsInventoryItemsEmpty())
        {
            await ShowEmptyInventoryItemsError();
            return;
        }

        var navigationParameter = new Dictionary<string, object>
        {
            { "Inventory", Inventory! },
            { "STNumber", STNumber! }
        };        

        await Shell.Current.GoToAsync($"{nameof(GeneralPage)}", navigationParameter);

        STNumber = string.Empty;
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

        SetCaption("Label_0016");
    }

    [RelayCommand]
    private async Task Save()
    {
        var inventoryItems = StorageService.GetInventoryItems();
        await _csvFileService.SaveCsvFileAsync(inventoryItems);
    }

    [RelayCommand]
    private static async Task Close()
    {
        var shouldExit = await ShouldExit();

        if (shouldExit) Environment.Exit(0);
    }

    private static async Task ShowEmptyStNumberError()
        => await DisplayHelper.DisplayToast("Label_0046");

    private static async Task ShowEmptyInventoryItemsError()
        => await DisplayHelper.DisplayToast("Label_0047");

    private static async Task<bool> ShouldRemoveExistingDatabase()
        => await DisplayHelper.DisplayAlert("Label_0042", "Label_0043", "Label_0044", "Label_0045");

    private static async Task<bool> ShouldExit()
        => await DisplayHelper.DisplayAlert("Label_0042", "Label_0064", "Label_0044", "Label_0045");
}
