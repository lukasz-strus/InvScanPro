using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace InvScanPro.ViewModels;

public partial class DataViewModel : ObservableObject
{
    [RelayCommand]
    async Task NavigateToLocationPage()
    {
        //TODO create location page and navigate mechanism
    }
}
