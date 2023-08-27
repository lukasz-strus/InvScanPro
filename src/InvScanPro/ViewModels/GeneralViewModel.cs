using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Models;

namespace InvScanPro.ViewModels;

[QueryProperty(nameof(Inventory), "Inventory")]
public partial class GeneralViewModel : ObservableObject
{
    [ObservableProperty]
    Inventory inventory;


    [RelayCommand]
    async Task LoadFile()
    {
        //TODO create load file mechanism
    }
}
