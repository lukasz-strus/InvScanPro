using CommunityToolkit.Mvvm.ComponentModel;
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
}
