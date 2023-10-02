using Camera.MAUI;
using CommunityToolkit.Maui.Views;

namespace InvScanPro.Views;

public partial class ScannerPage : Popup
{
    private bool isScanning = false;

    public ScannerPage()
    {
        InitializeComponent();

        InitializeBarCodeOptions();
    }

    private void InitializeBarCodeOptions()
    {
        CameraView.BarCodeOptions = new()
        {
            AutoRotate = true,

            PossibleFormats =
            {
                ZXing.BarcodeFormat.QR_CODE,
                ZXing.BarcodeFormat.All_1D
            }
        };
    }

    private void CameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (CameraView.Cameras.Count > 0)
        {
            CameraView.Camera = CameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await CameraView.StopCameraAsync();
                await CameraView.StartCameraAsync();
            });
        }
    }

    private void CameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        if (isScanning) return;

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            isScanning = true;
            Vibration.Default.Vibrate(new TimeSpan(0, 0, 0, 0, 100));
            await CameraView.StopCameraAsync();
            await CloseAsync(args.Result[0].Text);
        });
    }
}