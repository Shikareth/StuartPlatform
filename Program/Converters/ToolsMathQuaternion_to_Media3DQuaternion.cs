using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Program.Converters
{
    [ValueConversion(typeof(Tools.Math.Quaternion), typeof(System.Windows.Media.Media3D.Quaternion))]
    public class ToolsMathQuaternion_to_Media3DQuaternion : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Windows.Media.Media3D.Quaternion result = new System.Windows.Media.Media3D.Quaternion(0, 0, 0, 1);

            if(value!=null)
                if(value.GetType() == typeof(Tools.Math.Quaternion))
                {
                    var q = (Tools.Math.Quaternion)value;

                    result.W = q.W;
                    result.X = q.X;
                    result.Y = q.Y;
                    result.Z = q.Z;
                }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
