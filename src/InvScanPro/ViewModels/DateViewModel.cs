using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace InvScanPro.ViewModels;

public partial class DateViewModel : ObservableObject
{
    [ObservableProperty]
    DateTime date = DateTime.Now; // TODO get date from file

    [RelayCommand]
    async Task NavigateToLocationPage()
    {
        await Shell.Current.GoToAsync($"{nameof(LocationPage)}?Date={Date}");
    }

    [RelayCommand]
    async Task LoadFile()
    {
        //TODO create load file mechanism
    }
}
