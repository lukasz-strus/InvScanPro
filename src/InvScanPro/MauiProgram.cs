using InvScanPro.ViewModels;
using Microsoft.Extensions.Logging;
using InvScanPro.Extensions;
using Camera.MAUI;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;

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
        })
            .UseMauiCameraView()
            .UseMauiCommunityToolkit();

        builder.Services.AddSingleton(FileSaver.Default);
        builder.Services.AddPages();
        builder.Services.AddViewModels();
        builder.Services.AddServices();
        return builder.Build();
    }
}