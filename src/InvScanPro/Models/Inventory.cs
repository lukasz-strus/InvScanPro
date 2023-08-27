namespace InvScanPro.Models;

public class Inventory
{
    public string Location { get; set; }
    public DateTime Date { get; set; }

    public Inventory(string location, DateTime date)
    {
        Location = location;
        Date = date;
    }
}
