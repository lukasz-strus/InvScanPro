using InvScanPro.ViewModels;

namespace InvScanPro;

public partial class DatePage : ContentPage
{
	public DatePage(DateViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}