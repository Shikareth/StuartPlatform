using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Program.Converters
{
    [ValueConversion(typeof(double), typeof(double))]
    public class Double_to_Multiplied : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double result = 0.0;

            if (values != null)
                if (values.Count() == 2)
                    if (double.TryParse(values[0].ToString(), out double v1) && double.TryParse(values[1].ToString(), out double v2))
                        result = v1 * v2;

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
