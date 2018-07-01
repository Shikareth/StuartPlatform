using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Program.Converters
{
    [ValueConversion(typeof(Models.StuartPlatform.Actuator), typeof(System.Windows.Media.SolidColorBrush))]
    public class Actuator_to_Fill : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Windows.Media.SolidColorBrush result = System.Windows.Media.Brushes.Green;

            if (value != null)
                if(value.GetType() == typeof(Models.StuartPlatform.Actuator))
                {
                    var actuator = (Models.StuartPlatform.Actuator)value;
                    var length = actuator.ActualLength;

                    if (length <= actuator.MinLength) result = System.Windows.Media.Brushes.Blue;
                    if (length >= actuator.MaxLength) result = System.Windows.Media.Brushes.Red;
                }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
