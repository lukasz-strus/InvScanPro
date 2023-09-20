﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Helpers;
using InvScanPro.Models;
using InvScanPro.Services;
using InvScanPro.Views;

namespace InvScanPro.ViewModels;

public partial class DateViewModel : ObservableObject
{
    [ObservableProperty] private DateTime date;

    private readonly ICsvFileService _csvFileService;
    private readonly IStorageService _storageService;

    public DateViewModel(
        ICsvFileService csvFileService, 
        IStorageService storageService)
    {
        _csvFileService = csvFileService;
        _storageService = storageService;

        Date = CacheHelper.GetDateFromCache(_storageService);
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

        Date = CacheHelper.GetDateFromCache(_storageService);
    }
}
