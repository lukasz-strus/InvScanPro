using InvScanPro.ViewModels;

namespace InvScanPro;

public partial class DataPage : ContentPage
{
	public DataPage(DataViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}