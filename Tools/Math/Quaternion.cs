using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Math
{
    public class Quaternion
    {
        public double W { get; set; } = 0.0;
        public double X { get; set; } = 0.0;
        public double Y { get; set; } = 0.0;
        public double Z { get; set; } = 0.0;
        public static Quaternion I { get; } = new Quaternion(1, 0, 0, 0);

        public Quaternion Unit
        {
            get {
                return (this / Norm); 
            }
        }
        public Quaternion Conjugate
        {
            get {
                return new Quaternion(W, -X, -Y, -Z);
            }
        }
        public double Norm
        {
            get {
                return System.Math.Sqrt(W * W + X * X + Y * Y + Z * Z);
            }
        }
        public double Norm2
        {
            get {
                return W * W + X * X + Y * Y + Z * Z;
            }
        }
        public Quaternion Inverse
        {
            get {
                return (Conjugate / Norm2);
            }
        }

        public Vector3D Vector
        {
            get {
                return new Vector3D(X, Y, Z);
            }
        }
        public double Scalar
        {
            get {
                return W;
            }
        }

        public Quaternion()
        {

        }

        public Quaternion(double w, double x, double y, double z)
        {
            W = w;
            X = x;
            Y = y;
            Z = z;
        }

        public Quaternion(double angle, Vector3D axis)
        {
            double s = System.Math.Sin(angle / 2);
            W = System.Math.Cos(angle / 2);
            X = -axis.X * s;
            Y = -axis.Y * s;
            Z = -axis.Z * s;
        }

        public Quaternion(Vector3D v)
        {
            W = 0.0;
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        public Vector3D Rotate(Vector3D v)
        {
            var result = this * new Quaternion(v) * Inverse;
            return new Vector3D(result.X, result.Y, result.Z);
        }

        public static double Distance(Quaternion q1, Quaternion q2)
        {
            return (q1 - q2).Norm;
        }

        public static Quaternion operator +(Quaternion q1, Quaternion q2)
        {
            return new Quaternion()
            {
                W = q1.W + q2.W,
                X = q1.X + q2.X,
                Y = q1.Y + q2.Y,
                Z = q1.Z + q2.Z,
            };
        }
        public static Quaternion operator +(double q1, Quaternion q2)
        {
            return new Quaternion()
            {
                W = q1 + q2.W,
                X = q1 + q2.X,
                Y = q1 + q2.Y,
                Z = q1 + q2.Z,
            };
        }
        public static Quaternion operator +(Quaternion q1, double q2)
        {
            return new Quaternion()
            {
                W = q1.W + q2,
                X = q1.X + q2,
                Y = q1.Y + q2,
                Z = q1.Z + q2,
            };
        }

        public static Quaternion operator -(Quaternion q1, Quaternion q2)
        {
            return new Quaternion()
            {
                W = q1.W - q2.W,
                X = q1.X - q2.X,
                Y = q1.Y - q2.Y,
                Z = q1.Z - q2.Z,
            };
        }
        public static Quaternion operator -(double q1, Quaternion q2)
        {
            return new Quaternion()
            {
                W = q1 - q2.W,
                X = q1 - q2.X,
                Y = q1 - q2.Y,
                Z = q1 - q2.Z,
            };
        }
        public static Quaternion operator -(Quaternion q1, double q2)
        {
            return new Quaternion()
            {
                W = q1.W - q2,
                X = q1.X - q2,
                Y = q1.Y - q2,
                Z = q1.Z - q2,
            };
        }

        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            return new Quaternion()
            {
                W = q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z,
                X = q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y,
                Y = q1.W * q2.Y - q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X,
                Z = q1.W * q2.Z + q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W
            };
        }
        public static Quaternion operator *(double q1, Quaternion q2)
        {
            return new Quaternion()
            {
                W = q1 * q2.W,
                X = q1 * q2.X,
                Y = q1 * q2.Y,
                Z = q1 * q2.Z,
            };
        }
        public static Quaternion operator *(Quaternion q1, double q2)
        {
            return new Quaternion()
            {
                W = q1.W * q2,
                X = q1.X * q2,
                Y = q1.Y * q2,
                Z = q1.Z * q2,
            };
        }

        public static Quaternion operator /(double q1, Quaternion q2)
        {
            return new Quaternion()
            {
                W = q1 / q2.W,
                X = q1 / q2.X,
                Y = q1 / q2.Y,
                Z = q1 / q2.Z,
            };
        }
        public static Quaternion operator /(Quaternion q1, double q2)
        {
            return new Quaternion()
            {
                W = q1.W / q2,
                X = q1.X / q2,
                Y = q1.Y / q2,
                Z = q1.Z / q2,
            };
        }

        public override string ToString()
        {
            return $"{W} {X} {Y} {Z}";
        }
        public string ToString(string format = "N3")
        {
            return $"{W.ToString(format)} {X.ToString(format)} {Y.ToString(format)} {Z.ToString(format)}";
        }
    }
}
