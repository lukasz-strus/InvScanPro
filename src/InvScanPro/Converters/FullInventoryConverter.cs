using InvScanPro.Models;
using System.Globalization;

namespace InvScanPro.Converters;

internal class FullInventoryConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is Inventory inventory
        ? $"Data: {inventory.Date.ToShortDateString()}; pom.: {inventory.Location}"
        : (object)string.Empty;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => string.Empty;
}