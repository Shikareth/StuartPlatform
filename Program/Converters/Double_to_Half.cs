using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Program.Converters
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public class Double_to_Half : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double result = 0.0;

            if (value != null)
                if (double.TryParse(value.ToString(), out double v))
                    result = v / 2.0;

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
