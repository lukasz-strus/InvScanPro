using CommunityToolkit.Maui.Views;
using InvScanPro.Helpers;
using InvScanPro.ViewModels;

namespace InvScanPro.Views;

public partial class GeneralPage : ContentPage
{
	private GeneralViewModel _vm;
    private readonly ScannerPage _scannerPage;

    public GeneralPage(GeneralViewModel vm, ScannerPage scannerPage)
	{
		InitializeComponent();
        _vm = vm;
        _scannerPage = scannerPage;
        BindingContext = _vm;
	}

    private async void EntryTapped(object sender, EventArgs e)
    {
        bool result = await ShouldUseQRScanner();
        if (!result) return;

        eSTNumber.Unfocus();

        var popup = new ScannerPage(_vm);
        this.ShowPopup(popup);
        await new TaskFactory().StartNew(() => { Thread.Sleep(5000); });
        await popup.CloseAsync();
    }

    private static async Task<bool> ShouldUseQRScanner()
        => await DisplayHelper.DisplayAlert("Label_0051", "Label_0052", "Label_0044", "Label_0045");
}