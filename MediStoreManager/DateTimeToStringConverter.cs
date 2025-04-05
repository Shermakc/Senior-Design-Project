using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MediStoreManager
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime && dateTime != DateTime.MinValue)
            {
                return dateTime.ToString("d"); // Short date pattern (e.g., 3/27/2025)
            }
            return string.Empty; // Do not show anything if it's MinValue
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Usually not needed for display-only
            throw new NotImplementedException();
        }
    }
}
