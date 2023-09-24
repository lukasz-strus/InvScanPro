using InvScanPro.ViewModels;

namespace InvScanPro.Views;

public partial class StartInventoryPage : ContentPage
{
	public StartInventoryPage(StartInventoryViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}