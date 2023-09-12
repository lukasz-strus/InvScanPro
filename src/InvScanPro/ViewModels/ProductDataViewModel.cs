using CommunityToolkit.Mvvm.ComponentModel;
using InvScanPro.Models;

namespace InvScanPro.ViewModels;

[QueryProperty(nameof(Inventory), "Inventory")]
public partial class ProductDataViewModel : ObservableObject
{
    [ObservableProperty]
    Inventory? inventory;
}
