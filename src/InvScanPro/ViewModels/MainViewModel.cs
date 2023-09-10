using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Views;

namespace InvScanPro.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand]
    async Task NavigateToDataPage()
    {
        await Shell.Current.GoToAsync(nameof(DatePage));
    }

    [RelayCommand]
    async Task NavigateToFilterPage()
    {
        await Shell.Current.GoToAsync(nameof(FilterPage));
    }
}
