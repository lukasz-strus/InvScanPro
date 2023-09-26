using InvScanPro.Views;

namespace InvScanPro
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterPagesRoutes();
        }

        private static void RegisterPagesRoutes()
        {
            Routing.RegisterRoute(nameof(DatePage), typeof(DatePage));
            Routing.RegisterRoute(nameof(LocationPage), typeof(LocationPage));
            Routing.RegisterRoute(nameof(GeneralPage), typeof(GeneralPage));
            Routing.RegisterRoute(nameof(FilterPage), typeof(FilterPage));
            Routing.RegisterRoute(nameof(ProductDataPage), typeof(ProductDataPage));
            Routing.RegisterRoute(nameof(AddProductPage), typeof(AddProductPage));
            Routing.RegisterRoute(nameof(StartInventoryPage), typeof(StartInventoryPage));
        }
    }
}