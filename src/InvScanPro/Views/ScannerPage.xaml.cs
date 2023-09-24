using InvScanPro.ViewModels;
using CommunityToolkit.Maui.Views;
using Camera.MAUI;

namespace InvScanPro.Views;

public partial class ScannerPage : Popup
{
	private readonly GeneralViewModel _vm;
	private bool isScanning = false;
    public ScannerPage(GeneralViewModel vm)
	{
		InitializeComponent();
		_vm = vm;
		BindingContext = _vm;
	}

    private void CameraView_CamerasLoaded(object sender, EventArgs e)
    {
		if(CameraView.Cameras.Count > 0)
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
            await CameraView.StopCameraAsync();

            var result = args.Result[0].Text;

			//_vm.ScannedProduct.STNumber = result;
			//_vm.SearchCommand.Execute(result);

			await this.CloseAsync(result);
        });
    }
}