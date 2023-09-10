using InvScanPro.ViewModels;

namespace InvScanPro.Views;

public partial class DatePage : ContentPage
{
	public DatePage(DateViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}