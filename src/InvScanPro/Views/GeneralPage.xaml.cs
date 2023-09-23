using CommunityToolkit.Maui.Views;
using InvScanPro.Helpers;
using InvScanPro.ViewModels;

namespace InvScanPro.Views;

public partial class GeneralPage : ContentPage
{
	private GeneralViewModel _vm;
	public GeneralPage(GeneralViewModel vm)
	{
		InitializeComponent();
        _vm = vm;
        BindingContext = _vm;
	}

    private async void EntryTapped(object sender, EventArgs e)
    {
        bool result = await ShouldUseQRScanner();
        if (!result) return;

        var popup = new ScannerPage(_vm);
        this.ShowPopup(popup);
    }

    private static async Task<bool> ShouldUseQRScanner()
    {
        return await DisplayHelper.DisplayAlert("Label_0051", "Label_0052", "Label_0044", "Label_0045");
    }
}