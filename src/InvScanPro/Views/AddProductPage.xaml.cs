using InvScanPro.ViewModels;

namespace InvScanPro.Views;

public partial class AddProductPage : ContentPage
{
	public AddProductPage(AddProductViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}