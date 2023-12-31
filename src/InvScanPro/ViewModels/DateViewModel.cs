﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Helpers;
using InvScanPro.Models;
using InvScanPro.Services;
using InvScanPro.Views;

namespace InvScanPro.ViewModels;

public partial class DateViewModel : BaseViewModel
{
    [ObservableProperty] private DateTime _date;

    private readonly ICsvFileService _csvFileService;

    public DateViewModel(
        ICsvFileService csvFileService, 
        IStorageService storageService) : base(storageService)
    {
        _csvFileService = csvFileService;

        SetCaption("Label_0013");
        SetDate();        
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
            var shouldRemoveExistingDatabase = await ShouldRemoveExistingDatabase();
            if (!shouldRemoveExistingDatabase) return;
        }

        var inventoryItems = await _csvFileService.LoadCsvFileAsync();

        _storageService.SetInventoryItems(inventoryItems);

        SetDate();
        SetCaption("Label_0013");
    }

    private void SetDate() => Date = CacheHelper.GetDateFromCache(_storageService);

    private static async Task<bool> ShouldRemoveExistingDatabase()
        => await DisplayHelper.DisplayAlert("Label_0042", "Label_0043", "Label_0044", "Label_0045");

}
