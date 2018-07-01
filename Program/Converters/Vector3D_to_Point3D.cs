using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Program.Converters
{
    [ValueConversion(typeof(Tools.Math.Vector3D), typeof(System.Windows.Media.Media3D.Point3D))]
    public class Vector3D_to_Point3D : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Windows.Media.Media3D.Point3D result = new System.Windows.Media.Media3D.Point3D(0, 0, 0);

            if(value != null)
                if(value.GetType() == typeof(Tools.Math.Vector3D))
                {
                    var v = ((Tools.Math.Vector3D)value);
                    result.X = v.X;
                    result.Y = v.Y;
                    result.Z = v.Z;
                }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
