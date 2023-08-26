using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace InvScanPro.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand]
    async Task NavigateToInventoryPage()
    {
        //TODO create inventory page and navigate mechanism
    }

    [RelayCommand]
    async Task NavigateToInformationPage()
    {
        //TODO create information page and navigate mechanism
    }
}
