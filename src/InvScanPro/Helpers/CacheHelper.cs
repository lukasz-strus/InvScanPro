using InvScanPro.Services;

namespace InvScanPro.Helpers;

internal static class CacheHelper
{
    internal static DateTime GetDateFromCache(IStorageService cacheService)
        => IsListEmpty(cacheService) || IsDateNull(cacheService)
            ? DateTime.Now
            : GetDateFromList(cacheService);

    private static DateTime GetDateFromList(IStorageService cacheService) 
        => (DateTime)cacheService.GetInventoryItems().First(x => x.Date != null).Date!;

    private static bool IsDateNull(IStorageService cacheService)
        => cacheService.GetInventoryItems().All(x => x.Date == null);

    private static bool IsListEmpty(IStorageService cacheService)
        => cacheService.IsInventoryItemsEmpty();
}
