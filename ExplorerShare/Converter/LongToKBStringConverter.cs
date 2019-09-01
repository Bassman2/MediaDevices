using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ExplorerCtrl.Converter
{
    [ValueConversion(typeof(long), typeof(string))]
    public class LongToKBStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long k = (long)Math.Ceiling((long)value / 1024.0);
            return $"{k:N0} KB";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
