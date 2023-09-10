using InvScanPro.ViewModels;

namespace InvScanPro.Views;

public partial class FilterPage : ContentPage
{
	public FilterPage(FilterViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}