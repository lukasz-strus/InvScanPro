using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Models;
using InvScanPro.Views;

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

    [RelayCommand]
    async Task SaveQuantity()
    {
        //TODO create save quantity mechanism
    }
}
