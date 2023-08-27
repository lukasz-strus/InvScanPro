using InvScanPro.ViewModels;

namespace InvScanPro;

public partial class LocationPage : ContentPage
{
	public LocationPage(LocationViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}