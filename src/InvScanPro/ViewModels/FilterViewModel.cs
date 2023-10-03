using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InvScanPro.Models;
using InvScanPro.Views;

namespace InvScanPro.ViewModels;

public partial class FilterViewModel : ObservableObject
{
    [ObservableProperty] private Inventory _inventory;

    public FilterViewModel()
    {
        Inventory = new Inventory
        {
            Date = DateTime.Now,            
        };
    }

    [RelayCommand]
    private async Task Filter()
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Inventory", Inventory }
        };

        await Shell.Current.GoToAsync(nameof(ProductDataPage), navigationParameter);
    }
}
