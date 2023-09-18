using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CsvHelper;
using CsvHelper.Configuration;
using InvScanPro.Models;
using InvScanPro.Services;
using InvScanPro.Views;
using System.Globalization;
using System.Runtime.Caching;

namespace InvScanPro.ViewModels;

public partial class DateViewModel : ObservableObject
{
    private readonly ICsvFileService _csvFileService;

    [ObservableProperty]
    DateTime date = DateTime.Now; // TODO get date from file

    public DateViewModel(ICsvFileService csvFileService)
    {
        _csvFileService = csvFileService;
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
    async Task LoadFile() //TODO move to service
    {
        var inventoryItems = await _csvFileService.LoadCsvFileAsync();
        
    }
}
