using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace InvScanPro.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand]
    async Task NavigateToDataPage()
    {
        await Shell.Current.GoToAsync(nameof(DatePage));
    }

    [RelayCommand]
    async Task NavigateToInformationPage()
    {
        //TODO create information page and navigate mechanism
    }
}
