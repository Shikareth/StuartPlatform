using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Math
{
    public class Vector3D
    {
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        public double Z { get; set; } = 0;
        public double[] Data
        {
            get {
                return new double[3] { X, Y, Z };
            }
        }


        public double Length
        {
            get {
                return System.Math.Sqrt(System.Math.Pow(X, 2) + System.Math.Pow(Y, 2) + System.Math.Pow(Z, 2));
            }
        }

        public Vector3D()
        {

        }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3D(IEnumerable<double> data)
        {
            var d = data.ToArray();

            X = d[0];
            Y = d[1];
            Z = d[2];
        }

        public Vector3D Normalized()
        {
            var length = Length;
            if (length == 0) return null;

            return new Vector3D(X / length, Y / length, Z / length);
        }
        public void Normalize()
        {
            var length = Length;
            if (length == 0) return;

            X /= length;
            Y /= length;
            Z /= length;
        }

        public static double DotProduct(Vector3D v, Vector3D p)
        {
            return v.X * p.X + v.Y * p.Y + v.Z * p.Z;
        }
        public static Vector3D CrossProduct(Vector3D v, Vector3D p)
        {
            return new Vector3D(v.Y * p.Z - v.Z * p.Y, v.Z * p.X - v.X * p.Z, v.X * p.Y - v.Y * p.X);
        }

        public static Vector3D operator +(Vector3D v, double p)
        {
            return new Vector3D(v.X + p, v.Y + p, v.Z + p);
        }
        public static Vector3D operator +(double p, Vector3D v)
        {
            return new Vector3D(v.X + p, v.Y + p, v.Z + p);
        }
        public static Vector3D operator +(Vector3D v, Vector3D p)
        {
            return new Vector3D(v.X + p.X, v.Y + p.Y, v.Z + p.Z);
        }

        public static Vector3D operator -(Vector3D v, double p)
        {
            return new Vector3D(v.X - p, v.Y - p, v.Z - p);
        }
        public static Vector3D operator -(double p, Vector3D v)
        {
            return new Vector3D(v.X - p, v.Y - p, v.Z - p);
        }
        public static Vector3D operator -(Vector3D v, Vector3D p)
        {
            return new Vector3D(v.X - p.X, v.Y - p.Y, v.Z - p.Z);
        }

        public static Vector3D operator *(Vector3D v, double p)
        {
            return new Vector3D(v.X * p, v.Y * p, v.Z * p);
        }
        public static Vector3D operator *(double p, Vector3D v)
        {
            return new Vector3D(v.X * p, v.Y * p, v.Z * p);
        }

        public static Vector3D operator /(Vector3D v, double p)
        {
            return new Vector3D(v.X / p, v.Y / p, v.Z / p);
        }
        public static Vector3D operator /(double p, Vector3D v)
        {
            return new Vector3D(v.X / p, v.Y / p, v.Z / p);
        }

        public static Vector3D operator ~(Vector3D v)
        {
            return new Vector3D(-v.X, -v.Y, -v.Z);
        }

        public static Vector3D iX = new Vector3D(1, 0, 0);
        public static Vector3D iY = new Vector3D(0, 1, 0);
        public static Vector3D iZ = new Vector3D(0, 0, 1);

        public override string ToString()
        {
            return $"|\t {X.ToString("N3")}\t {Y.ToString("N3")}\t {Z.ToString("N3")}\t |";
        }
        public string ToString(string format = "E3")
        {
            return $"|\t {X.ToString(format)}\t {Y.ToString(format)}\t {Z.ToString(format)}\t |";
        }
    }

}

