using BarcodeScanner.Mobile;
using CommunityToolkit.Maui.Views;

namespace InvScanPro.Views;

public partial class ScannerPage : Popup
{ public ScannerPage()
    {
        InitializeComponent();

        Methods.AskForRequiredPermission();
    }

    private void CameraView_OnOnDetected(object? sender, OnDetectedEventArg e)
    {
        MainThread.BeginInvokeOnMainThread(Action);
        return;

        async void Action()
        {
            CameraView.IsScanning = false;
            await CloseAsync(e.BarcodeResults[0].DisplayValue);
        }
    }
}