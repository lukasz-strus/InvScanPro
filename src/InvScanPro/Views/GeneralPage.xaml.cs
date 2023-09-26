using CommunityToolkit.Maui.Views;
using InvScanPro.Helpers;
using InvScanPro.ViewModels;

namespace InvScanPro.Views;

public partial class GeneralPage : ContentPage
{
    public GeneralPage(GeneralViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}