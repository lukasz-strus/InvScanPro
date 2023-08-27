using InvScanPro.ViewModels;
using Microsoft.Extensions.Logging;
using InvScanPro.Extensions;

namespace InvScanPro;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddPages();
        builder.Services.AddViewModels();

        return builder.Build();
    }
}