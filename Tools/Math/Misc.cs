using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Math;

namespace Tools.Math
{
    public static class Misc
    {
        public static Vector2D PolarToCartesian(Vector2D v)
        {
            return new Vector2D()
            {
                X = v.X * System.Math.Cos(v.Y),
                Y = v.X * System.Math.Sin(v.Y)
            };
        }
        public static Vector2D PolarToCartesian(double R, double A)
        {
            return new Vector2D()
            {
                X = R * System.Math.Cos(A),
                Y = R * System.Math.Sin(A)
            };
        }

        public static Vector2D CartesianToPolar(Vector2D v)
        {
            return new Vector2D()
            {
                X = System.Math.Sqrt(System.Math.Pow(v.X, 2) + System.Math.Pow(v.Y, 2)),
                Y = System.Math.Atan2(v.Y, v.X)
            };
        }
        public static Vector2D CartesianToPolar(double X, double Y)
        {
            return new Vector2D()
            {
                X = System.Math.Sqrt(System.Math.Pow(X, 2) + System.Math.Pow(Y, 2)),
                Y = System.Math.Atan2(Y, X)
            };
        }

        public static double DegToRad(double value)
        {
            return value / 180 * System.Math.PI;
        }
        public static double RadToDeg(double value)
        {
            return 180 * value / System.Math.PI;
        }

        public static double Map(double From_min, double From_max, double To_min, double To_max, double value)
        {
            return To_min + ((To_max - To_min) / (From_max - From_min)) * (value - From_min);
        }
    }
}
