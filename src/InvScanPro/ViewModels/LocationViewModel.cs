using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace InvScanPro.ViewModels;

[QueryProperty("Date", "Date")]
public partial class LocationViewModel : ObservableObject
{
    [ObservableProperty]
    string location;

    [ObservableProperty]
    string date;

    [RelayCommand]
    async void NavigateToGeneralPage()
    {
        //TODO create general page and navigate mechanism
    }

    [RelayCommand]
    async Task LoadFile()
    {
        //TODO create load file mechanism
    }
}
