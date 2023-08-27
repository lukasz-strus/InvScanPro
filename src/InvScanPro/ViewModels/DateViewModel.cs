using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace InvScanPro.ViewModels;

public partial class DateViewModel : ObservableObject
{
    public string Date { get; set; }

    [RelayCommand]
    async Task NavigateToLocationPage()
    {
        //TODO create location page and navigate mechanism
    }
}
