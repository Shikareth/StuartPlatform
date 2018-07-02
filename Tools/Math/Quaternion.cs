using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Math
{
    public class Quaternion
    {
        public double A { get; set; } = 0.0;
        public double B { get; set; } = 0.0;
        public double C { get; set; } = 0.0;
        public double D { get; set; } = 0.0;

        public Quaternion Unit
        {
            get {
                return (this / Norm);
            }
        }
        public Quaternion Conjugate
        {
            get {
                return new Quaternion(A, -B, -C, -D);
            }
        }
        public Quaternion Inverse
        {
            get {
                return null; //TODO Quaternion Inverse
            }
        }

        public Vector3D Vector
        {
            get {
                return new Vector3D(B, C, D);
            }
        }
        public double Scalar
        {
            get {
                return A;
            }
        }

        public double Norm
        {
            get {
                return System.Math.Sqrt(System.Math.Pow(A, 2) + System.Math.Pow(B, 2) + System.Math.Pow(C, 2) + System.Math.Pow(D, 2));
            }
        }

        public Quaternion()
        {

        }

        public Quaternion(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public Quaternion(double scalar, Vector3D vector)
        {
            A = scalar;
            B = vector.X;
            C = vector.Y;
            D = vector.Z;
        }



        public static Quaternion operator +(Quaternion q1, Quaternion q2)
        {
            return new Quaternion()
            {
                A = q1.A + q2.A,
                B = q1.B + q2.B,
                C = q1.C + q2.C,
                D = q1.D + q2.D,
            };
        }
        public static Quaternion operator +(double q1, Quaternion q2)
        {
            return new Quaternion()
            {
                A = q1 + q2.A,
                B = q1 + q2.B,
                C = q1 + q2.C,
                D = q1 + q2.D,
            };
        }
        public static Quaternion operator +(Quaternion q1, double q2)
        {
            return new Quaternion()
            {
                A = q1.A + q2,
                B = q1.B + q2,
                C = q1.C + q2,
                D = q1.D + q2,
            };
        }

        public static Quaternion operator -(Quaternion q1, Quaternion q2)
        {
            return new Quaternion()
            {
                A = q1.A - q2.A,
                B = q1.B - q2.B,
                C = q1.C - q2.C,
                D = q1.D - q2.D,
            };
        }
        public static Quaternion operator -(double q1, Quaternion q2)
        {
            return new Quaternion()
            {
                A = q1 - q2.A,
                B = q1 - q2.B,
                C = q1 - q2.C,
                D = q1 - q2.D,
            };
        }
        public static Quaternion operator -(Quaternion q1, double q2)
        {
            return new Quaternion()
            {
                A = q1.A - q2,
                B = q1.B - q2,
                C = q1.C - q2,
                D = q1.D - q2,
            };
        }

        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            return new Quaternion()
            {
                A = q1.A * q2.A - q1.B * q2.B - q1.C * q2.C - q1.D * q2.D,
                B = q1.A * q2.B + q1.B * q2.A - q1.C * q2.D - q1.D * q2.C,
                C = q1.A * q2.C - q1.B * q2.D + q1.C * q2.A + q1.D * q2.B,
                D = q1.A * q2.D + q1.B * q2.C - q1.C * q2.B + q1.D * q2.A
            };
        }
        public static Quaternion operator *(double q1, Quaternion q2)
        {
            return new Quaternion()
            {
                A = q1 * q2.A,
                B = q1 * q2.B,
                C = q1 * q2.C,
                D = q1 * q2.D,
            };
        }
        public static Quaternion operator *(Quaternion q1, double q2)
        {
            return new Quaternion()
            {
                A = q1.A * q2,
                B = q1.B * q2,
                C = q1.C * q2,
                D = q1.D * q2,
            };
        }

        public static Quaternion operator /(double q1, Quaternion q2)
        {
            return new Quaternion()
            {
                A = q1 / q2.A,
                B = q1 / q2.B,
                C = q1 / q2.C,
                D = q1 / q2.D,
            };
        }
        public static Quaternion operator /(Quaternion q1, double q2)
        {
            return new Quaternion()
            {
                A = q1.A / q2,
                B = q1.B / q2,
                C = q1.C / q2,
                D = q1.D / q2,
            };
        }





        public override string ToString()
        {
            return $"{A} {B} {C} {D}";
        }
    }
}
