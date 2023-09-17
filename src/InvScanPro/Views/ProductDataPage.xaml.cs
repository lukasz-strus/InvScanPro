using InvScanPro.ViewModels;

namespace InvScanPro.Views;

public partial class ProductDataPage : ContentPage
{
	public ProductDataPage(ProductDataViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

    }
}