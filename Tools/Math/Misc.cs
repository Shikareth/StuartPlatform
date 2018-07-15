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
                X = System.Math.Sqrt(v.X * v.X + v.Y * v.Y),
                Y = System.Math.Atan2(v.Y, v.X)
            };
        }
        public static Vector2D CartesianToPolar(double X, double Y)
        {
            return new Vector2D()
            {
                X = System.Math.Sqrt(X * X + Y * Y),
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

        public static double[] FindPolynomialRoot_BrentDekker(double a, double b, double[] function, double epsilon = double.Epsilon)
        {
            int rank = function.Length - 1;
            double[] roots = new double[rank];
            double s = double.NaN;
            double f_s = double.NaN;
            double d = double.NaN;

            // calculate f(a) and calculate f(b)
            double f_a = CalculatePolynomialValue(a, function);
            double f_b = CalculatePolynomialValue(b, function);

            // exit function because the root is not bracketed
            if (f_a * f_b >= 0) return null;
            if(System.Math.Abs(f_a) < System.Math.Abs(f_b))
            {
                double t = a;
                a = b;
                b = t;

                double f_t = f_a;
                f_a = f_b;
                f_b = f_t;
            }

            bool mflag = true;
            double c = a;
            double f_c;

            do
            {
               
                f_c = CalculatePolynomialValue(c, function);

                if (f_a != f_c && f_b != f_c)
                {
                    s = (a * f_c - b * f_c) / ((f_a - f_b) * (f_a - f_c)) +
                        (b * f_a - b * f_c) / ((f_b - f_a) * (f_b - f_c)) +
                        (c * f_a - b * f_b) / ((f_c - f_a) * (f_c - f_b));
                }
                else
                {
                    s = b - f_b * (b - a) / (f_b - f_a);
                }

                if (!InRange((3 * a + b) / 4, b, s) ||
                    (mflag && System.Math.Abs(s - b) >= System.Math.Abs(b - c) / 2) ||
                    (!mflag && System.Math.Abs(s - b) >= System.Math.Abs(c - d) / 2) ||
                    (mflag && System.Math.Abs(b - c) >= epsilon) ||
                    (!mflag && System.Math.Abs(c - d) >= epsilon))
                {
                    s = (a + b) / 2;
                    mflag = true;
                }
                else
                    mflag = false;

                f_s = CalculatePolynomialValue(s, function);
                d = c;
                c = b;

                if (f_a * f_s < 0)
                {
                    b = s;
                    f_b = f_s;
                }
                else
                {
                    a = s;
                    f_a = f_s;
                }

                if (System.Math.Abs(f_a) < System.Math.Abs(f_b))
                {
                    double t = a;
                    a = b;
                    b = t;

                    double f_t = f_a;
                    f_a = f_b;
                    f_b = f_t;
                }
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(string.Format("[{0:N3} : {1:N3}]", s, b));

                // repeat until f(b or s) = 0 or |b − a| is small enough (convergence)
            } while (f_s != 0 && f_b != 0 && System.Math.Abs(b - a) >= epsilon);

            roots[0] = s;
            roots[1] = b;

            return roots;
        }

        public static double CalculatePolynomialValue(double value, double[] function)
        {
            double result = 0;

            for (int n = 0; n < function.Length; n++)
                result += function[function.Length - 1 - n] * System.Math.Pow(value, n);

            return result;
        }

        public static bool InRange(double a, double b, double value)
        {
            double lower = a;
            double upper = b;
            if(a > b)
            {
                lower = b;
                upper = a;
            }

            return (value >= lower && value <= upper);
        }
    }
}
