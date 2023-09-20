namespace InvScanPro.Models;

public class InventoryItem
{
    public string Countingnum { get; set; } = default!;
    public string Barcode { get; set; } = default!;
    public string Name { get; set; } = default!;
    public int Count { get; set; }
    public string? Info1 { get; set; }
    public string? Info2 { get; set; }
    public string? Info3 { get; set; }
    public string? GroupId { get; set; }
    public string? DepertamentId { get; set; }
    public DateTime? ProductionDate { get; set; }
    public string UnitOfMeasure { get; set; } = default!;
    public decimal UnitCost { get; set; }
    public string? Location { get; set; }
    public DateTime? Date { get; set; }
}
