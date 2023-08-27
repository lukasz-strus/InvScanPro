using InvScanPro.ViewModels;

namespace InvScanPro.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddPages(this IServiceCollection services)
    {
        services.AddSingleton<MainPage>();
        services.AddSingleton<DatePage>();
        services.AddSingleton<LocationPage>();
    }

    public static void AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<DateViewModel>();
        services.AddSingleton<LocationViewModel>();
    }
}
