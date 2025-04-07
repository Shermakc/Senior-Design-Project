using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace MediStoreManager
{
    public class SuppliesTabVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int selectedIndex && selectedIndex == 1)
            {
                return Visibility.Visible; // Show button
            }
            return Visibility.Collapsed; // Hide button
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing; // Not needed for one-way binding
        }
    }
}
