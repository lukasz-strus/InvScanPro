using InvScanPro.ViewModels;

namespace InvScanPro.Views;

public partial class GeneralPage : ContentPage
{
	private GeneralViewModel _vm;
	public GeneralPage(GeneralViewModel vm)
	{
		InitializeComponent();
        _vm = vm;
        BindingContext = _vm;
	}

    private void EntryTapped(object sender, EventArgs e)
    {
        _vm.FocusedSTNumberCommand.Execute(null);
    }
}