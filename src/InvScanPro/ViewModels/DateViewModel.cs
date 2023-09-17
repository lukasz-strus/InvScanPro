using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CsvHelper;
using CsvHelper.Configuration;
using InvScanPro.Models;
using InvScanPro.Views;
using System.Globalization;

namespace InvScanPro.ViewModels;

public partial class DateViewModel : ObservableObject
{
    [ObservableProperty]
    DateTime date = DateTime.Now; // TODO get date from file

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
        var records = new List<InventoryItem>();

        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Select file to load"
        });

        if (result == null)
            return;

        var stream = await result.OpenReadAsync();

        using var reader = new StreamReader(stream);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
            HasHeaderRecord = false
        });

        while (csv.Read())
        {
            var item = new InventoryItem
            {
                Countingnum = csv.GetField<string>(0)!,
                Barcode = csv.GetField<string>(1)!,
                Name = csv.GetField<string>(2)!,
                Count = csv.GetField<int>(3),
                Info1 = csv.GetField<string?>(4),
                Info2 = csv.GetField<string?>(5),
                Info3 = csv.GetField<string?>(6),
                GroupId = csv.GetField<string?>(7),
                DepertamentId = csv.GetField<string?>(8),
                ProductionDate = csv.GetField<DateTime?>(11),
                UnitOfMeasure = csv.GetField<string>(12)!,
                UnitCost = csv.GetField<decimal>(13),
                Location = csv.GetField<string?>(15),
                Date = csv.GetField<DateTime?>(16)
            };

            records.Add(item);
        }
    }
}
