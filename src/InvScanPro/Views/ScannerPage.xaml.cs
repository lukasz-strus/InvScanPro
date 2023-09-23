using InvScanPro.ViewModels;
using CommunityToolkit.Maui.Views;

namespace InvScanPro.Views;

public partial class ScannerPage : Popup
{
	private readonly GeneralViewModel _vm;
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
        MainThread.BeginInvokeOnMainThread(async () =>
		{
			BarcodeResult.Text = $"{args.Result[0].BarcodeFormat}: {args.Result[0].Text}";
			var result = args.Result[0].Text;
			_vm.UpdateSTNumber(result);

			await CloseAsync();
        });
    }
}