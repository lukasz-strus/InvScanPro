using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Views;

namespace InvScanPro.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand]
    private async Task NavigateToDataPage()
    {
        await Shell.Current.GoToAsync(nameof(DatePage));
    }

    [RelayCommand]
    private async Task NavigateToFilterPage()
    {
        await Shell.Current.GoToAsync(nameof(FilterPage));
    }
}
