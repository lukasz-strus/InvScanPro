using InvScanPro.ViewModels;
using InvScanPro.Views;

namespace InvScanPro.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddPages(this IServiceCollection services)
    {
        services.AddSingleton<MainPage>();
        services.AddSingleton<DatePage>();
        services.AddSingleton<LocationPage>();
        services.AddSingleton<GeneralPage>();
        services.AddSingleton<FilterPage>();
    }

    public static void AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<DateViewModel>();
        services.AddSingleton<LocationViewModel>();
        services.AddSingleton<GeneralViewModel>();
        services.AddSingleton<FilterViewModel>();
    }
}
