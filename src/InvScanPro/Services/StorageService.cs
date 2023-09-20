using InvScanPro.Models;

namespace InvScanPro.Services;

public interface IStorageService
{
    void ClearInventoryItems();
    List<InventoryItem> GetInventoryItems();
    void SetInventoryItems(List<InventoryItem> inventoryItems);
    bool IsInventoryItemsEmpty();
}

public class StorageService : IStorageService
{
    private List<InventoryItem> _inventoryItems = new();

    public void SetInventoryItems(List<InventoryItem> inventoryItems) => _inventoryItems = inventoryItems;

    public List<InventoryItem> GetInventoryItems() => _inventoryItems;

    public void ClearInventoryItems() => _inventoryItems.Clear();

    public bool IsInventoryItemsEmpty() => _inventoryItems.Count == 0;

}
