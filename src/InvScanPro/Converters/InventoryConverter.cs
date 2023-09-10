using System.Globalization;
using InvScanPro.Models;

namespace InvScanPro.Converters;

internal class InventoryConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
        => value is Inventory inventory 
        ? $"{inventory.Date.ToShortDateString()}, {inventory.Location}" 
        : (object)string.Empty;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
        => string.Empty;
}
