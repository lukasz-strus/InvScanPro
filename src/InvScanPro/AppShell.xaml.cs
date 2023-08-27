namespace InvScanPro
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DataPage), typeof(DataPage));
        }
    }
}