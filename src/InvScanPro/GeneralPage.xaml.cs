using InvScanPro.ViewModels;

namespace InvScanPro;

public partial class GeneralPage : ContentPage
{
	public GeneralPage(GeneralViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}