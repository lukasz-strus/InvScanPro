using InvScanPro.Models;

namespace InvScanPro.Services;

public interface ICacheService
{
    void ClearInventoryItems();
    List<InventoryItem> GetInventoryItems();
    void SetInventoryItems(List<InventoryItem> inventoryItems);
}

public class CacheService : ICacheService
{
    private List<InventoryItem> _inventoryItems = new();

    public void SetInventoryItems(List<InventoryItem> inventoryItems) => _inventoryItems = inventoryItems;

    public List<InventoryItem> GetInventoryItems() => _inventoryItems;

    public void ClearInventoryItems() => _inventoryItems.Clear();

}
