namespace InvScanPro.Models;

public class Product
{
    public string? STNumber { get; set; } = default!;
    public string? Name { get; set; } = default!;
    public string? Info1 { get; set; } = default!;
    public string? Info2 { get; set; } = default!;
    public string? Info3 { get; set; } = default!;
    public int Quantity { get; set; }
}
