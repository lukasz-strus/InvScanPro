using InvScanPro.ViewModels;

namespace InvScanPro.Views;

public partial class LocationPage : ContentPage
{
	public LocationPage(LocationViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}