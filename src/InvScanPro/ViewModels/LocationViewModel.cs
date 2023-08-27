using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace InvScanPro.ViewModels;

public partial class LocationViewModel : ObservableObject
{
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
