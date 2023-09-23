using InvScanPro.Models;

namespace InvScanPro.Services;

public interface IStorageService
{
    void ClearInventoryItems();
    List<InventoryItem> GetInventoryItems();
    void SetInventoryItems(List<InventoryItem> inventoryItems);
    void AddInventoryItem(InventoryItem inventoryItem);
    bool IsInventoryItemsEmpty();
    InventoryItem? GetInventoryItem(string barcode);
}

public class StorageService : IStorageService
{
    private List<InventoryItem> _inventoryItems = new();

    public void SetInventoryItems(List<InventoryItem> inventoryItems) => _inventoryItems = inventoryItems;

    public List<InventoryItem> GetInventoryItems() => _inventoryItems;

    public void ClearInventoryItems() => _inventoryItems.Clear();

    public bool IsInventoryItemsEmpty() => _inventoryItems.Count == 0;

    public InventoryItem? GetInventoryItem(string barcode)
    {
        return _inventoryItems.ToList().FirstOrDefault(x => x.Barcode == barcode);
    }

    public void AddInventoryItem(InventoryItem inventoryItem) => _inventoryItems.Add(inventoryItem);
}
