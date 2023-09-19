using InvScanPro.Services;

namespace InvScanPro.Helpers;

internal static class CacheHelper
{
    internal static DateTime GetDateFromCache(ICacheService cacheService)
        => IsListEmpty(cacheService) || IsDateNull(cacheService)
            ? DateTime.Now
            : GetDateFromList(cacheService);

    private static DateTime GetDateFromList(ICacheService cacheService) 
        => (DateTime)cacheService.GetInventoryItems().First(x => x.Date != null).Date!;

    private static bool IsDateNull(ICacheService cacheService)
        => !cacheService.GetInventoryItems().Any(x => x.Date != null);

    private static bool IsListEmpty(ICacheService cacheService)
        => cacheService.IsInventoryItemsEmpty();
}
