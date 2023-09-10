using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Models;

namespace InvScanPro.ViewModels;

public partial class FilterViewModel : ObservableObject
{
    [ObservableProperty]
    Inventory? inventory;

    public FilterViewModel()
    {
        Inventory = new()
        {
            Date = DateTime.Now,            
        };
    }

    [RelayCommand]
    async Task Filter()
    {
        //TODO create filter mechanism
    }

    [RelayCommand]
    async Task Back()
    {
        //TODO create back mechanism
    }
}
