using System;
using System.Globalization;
using System.Windows.Data;

namespace ComputerStoreManagement.Converters
{
    public class CurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal decimalValue)
            {
                return decimalValue.ToString("N0") + " VND";
            }
            if (value is double doubleValue)
            {
                return doubleValue.ToString("N0") + " VND";
            }
            if (value is int intValue)
            {
                return intValue.ToString("N0") + " VND";
            }
            return "0 VND";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string strValue)
            {
                var cleanValue = strValue.Replace("VND", "").Replace(",", "").Trim();
                if (decimal.TryParse(cleanValue, out decimal result))
                {
                    return result;
                }
            }
            return 0m;
        }
    }
}
