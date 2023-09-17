using InvScanPro.ViewModels;
using InvScanPro.Views;

namespace InvScanPro.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddPages(this IServiceCollection services)
    {
        services.AddSingleton<MainPage>();

        services.AddTransient<DatePage>();
        services.AddTransient<LocationPage>();
        services.AddTransient<GeneralPage>();
        services.AddTransient<FilterPage>();
        services.AddTransient<ProductDataPage>();
    }

    public static void AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainViewModel>();

        services.AddTransient<DateViewModel>();
        services.AddTransient<LocationViewModel>();
        services.AddTransient<GeneralViewModel>();
        services.AddTransient<FilterViewModel>();
        services.AddTransient<ProductDataViewModel>();
    }
}
