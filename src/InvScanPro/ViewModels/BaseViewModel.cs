using CommunityToolkit.Mvvm.ComponentModel;
using InvScanPro.Services;

namespace InvScanPro.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty] private string? _caption;

    protected readonly IStorageService StorageService;

    public BaseViewModel(IStorageService storageService)
    {
        StorageService = storageService;
    }
    protected void SetCaption(string label)
    {
        Application.Current!.Resources.TryGetValue(label, out var title);

        var items = StorageService.GetInventoryItems();

        Caption = items.Count == 0 ? $"{title}" : $"{title} ({items[0].Countingnum})";
    }
}
