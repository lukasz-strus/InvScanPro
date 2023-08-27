using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Models;
using System.Globalization;

namespace InvScanPro.ViewModels;

[QueryProperty("Date", "Date")]
public partial class LocationViewModel : ObservableObject
{
    [ObservableProperty]
    string location;

    [ObservableProperty]
    string date;

    [RelayCommand]
    async Task NavigateToGeneralPage()
    {
        DateTime dateTime = SetDateTime(Date);
        var inventory = new Inventory(Location, dateTime);

        var navigationParameter = new Dictionary<string, object>
        {
            { "Inventory", inventory }
        };

        await Shell.Current.GoToAsync($"{nameof(GeneralPage)}", navigationParameter);
    }

    [RelayCommand]
    async Task LoadFile()
    {
        //TODO create load file mechanism
    }

    private DateTime SetDateTime(string dateString)
    {
        dateString = dateString.Replace("%20", " ");

        if (DateTime.TryParseExact(dateString, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
        {
            return result;
        }
        else
        {
            return DateTime.Now;
        }
    }
}
