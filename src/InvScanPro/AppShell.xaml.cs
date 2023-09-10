using InvScanPro.Views;

namespace InvScanPro
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DatePage), typeof(DatePage));
            Routing.RegisterRoute(nameof(LocationPage), typeof(LocationPage));
            Routing.RegisterRoute(nameof(GeneralPage), typeof(GeneralPage));
            
        }
    }
}