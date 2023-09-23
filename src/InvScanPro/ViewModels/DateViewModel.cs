using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Helpers;
using InvScanPro.Models;
using InvScanPro.Services;
using InvScanPro.Views;

namespace InvScanPro.ViewModels;

public partial class DateViewModel : ObservableObject
{
    [ObservableProperty] private DateTime _date;
    [ObservableProperty] private string? _caption;

    private readonly ICsvFileService _csvFileService;
    private readonly IStorageService _storageService;

    public DateViewModel(
        ICsvFileService csvFileService, 
        IStorageService storageService)
    {
        _csvFileService = csvFileService;
        _storageService = storageService;

        SetDate();
        SetCaption();
    }

    [RelayCommand]
    private async Task NavigateToLocationPage()
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
    private async Task LoadFile()
    {
        if (!_storageService.IsInventoryItemsEmpty())
        {
            bool result = await DisplayHelper.DisplayAlert("Label_0042", "Label_0043", "Label_0044", "Label_0045");

            if (!result) return;
        }

        var inventoryItems = await _csvFileService.LoadCsvFileAsync();

        _storageService.SetInventoryItems(inventoryItems);

        SetDate();
        SetCaption();
    }

    private void SetDate() => Date = CacheHelper.GetDateFromCache(_storageService);

    private void SetCaption()
    {        
        Application.Current!.Resources.TryGetValue("Label_0013", out object title);

        var items = _storageService.GetInventoryItems();

        Caption = items.Count == 0 ? $"{title}" : $"{title} {items[0].Countingnum}";
    }
}
