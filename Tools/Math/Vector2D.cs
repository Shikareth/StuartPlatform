using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Math
{
    public class Vector2D
    {
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        public double[] Data
        {
            get {
                return new double[2] { X, Y };
            }
        }

        public double Length
        {
            get {
                return System.Math.Sqrt(System.Math.Pow(X, 2) + System.Math.Pow(Y, 2));
            }
        }

        public Vector2D()
        {

        }

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector2D(IEnumerable<double> data)
        {
            var d = data.ToArray();

            X = d[0];
            Y = d[1];
        }

        public Vector2D Normalized()
        {
            var length = Length;
            if (length == 0) return null;

            return new Vector2D(X / length, Y / length);
        }
        public void Normalize()
        {
            var length = Length;
            if (length == 0) return;

            X /= length;
            Y /= length;
        }

        public static double DotProduct(Vector2D v, Vector2D p)
        {
            return v.X * p.X + v.Y * p.Y;
        }

        public static Vector2D operator +(Vector2D v, double p)
        {
            return new Vector2D(v.X + p, v.Y + p);
        }
        public static Vector2D operator +(double p, Vector2D v)
        {
            return new Vector2D(v.X + p, v.Y + p);
        }
        public static Vector2D operator +(Vector2D v, Vector2D p)
        {
            return new Vector2D(v.X + p.X, v.Y + p.Y);
        }

        public static Vector2D operator -(Vector2D v, double p)
        {
            return new Vector2D(v.X - p, v.Y - p);
        }
        public static Vector2D operator -(double p, Vector2D v)
        {
            return new Vector2D(v.X - p, v.Y - p);
        }
        public static Vector2D operator -(Vector2D v, Vector2D p)
        {
            return new Vector2D(v.X - p.X, v.Y - p.Y);
        }

        public static Vector2D operator *(Vector2D v, double p)
        {
            return new Vector2D(v.X * p, v.Y * p);
        }
        public static Vector2D operator *(double p, Vector2D v)
        {
            return new Vector2D(v.X * p, v.Y * p);
        }

        public static Vector2D operator /(Vector2D v, double p)
        {
            return new Vector2D(v.X / p, v.Y / p);
        }
        public static Vector2D operator /(double p, Vector2D v)
        {
            return new Vector2D(v.X / p, v.Y / p);
        }

        public static Vector2D operator ~(Vector2D v)
        {
            return new Vector2D(-v.X, -v.Y);
        }

        public override string ToString()
        {
            return $"|\t {X.ToString("N3")}\t {Y.ToString("N3")}\t |";
        }
        public string ToString(string format = "E3")
        {
            return $"|\t {X.ToString(format)}\t {Y.ToString(format)}\t |";
        }
    }
}
