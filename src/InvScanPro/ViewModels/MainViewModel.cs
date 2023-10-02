using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Helpers;
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

    [RelayCommand]
    private static async Task Close()
    {
        var shouldExit = await ShouldExit();

        if (shouldExit) Environment.Exit(0);
    }

    private static async Task<bool> ShouldExit()
        => await DisplayHelper.DisplayAlert("Label_0042", "Label_0064", "Label_0044", "Label_0045");

}
