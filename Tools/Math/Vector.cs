using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Tools.Math
{
    public class Vector
    {
        public double[] Data { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public double Length
        {
            get {
                double length = 0;
                for (int n = 0; n < Data.Length; n++)
                    length += Data[n] * Data[n];

                return System.Math.Sqrt(length);
            }
        }

        public Vector(IEnumerable<double> data)
        {
            Rows = data.Count();
            Columns = 1;
            Data = data.ToArray();
        }

        public Vector(bool vertical, IEnumerable<double> data)
        {
            if (!vertical)
            {
                Rows = data.Count();
                Columns = 1;
            }
            else
            {
                Rows = 1;
                Columns = data.Count();
            }

            Data = data.ToArray();
        }

        public Vector(int size, bool vertical, double value)
        {
            Data = new double[size];
            if (!vertical)
            {
                Rows = size;
                Columns = 1;
            }
            else
            {
                Rows = 1;
                Columns = size;
            }

            Parallel.For(0, size, (n) =>
            {
                Data[n] = value;
            });
        }

        public Vector(int rows, int columns, IEnumerable<double> data)
        {
            if (data.Count() != rows * columns) return;

            Rows = rows;
            Columns = columns;
            Data = data.ToArray();
        }

        public Vector Transposed()
        {
            double[] array = new double[Data.Length];
            Data.CopyTo(array, 0);

            return new Vector(Columns, Rows, array);
        }
        public void Transpose()
        {
            var columns = Columns;
            Columns = Rows;
            Rows = Columns;
        }

        public Vector Normalized()
        {
            double[] array = new double[Data.Length];
            double length = Length;

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = Data[n] / length;
            });

            return new Vector(Rows, Columns, array);
        }
        public void Normalize()
        {
            double[] array = new double[Data.Length];
            double length = Length;

            Parallel.For(0, Data.Length, (n) =>
            {
                array[n] = Data[n] / length;
            });

            array.CopyTo(Data, 0);
        }

        //TODO Vector CrossProduct(Vector A, Vector B) worth implementing?
        public Vector CrossProduct(Vector A, Vector B)
        {
            throw new NotImplementedException();
            if (A.Data.Length != B.Data.Length) return null;

            double[] array = new double[A.Data.Length];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A.Data[n] + B.Data[n];
            });

            return new Vector(A.Rows, A.Columns, array);
        }

        public double DotProduct(Vector A, Vector B)
        {
            if (A.Data.Length != B.Data.Length) return double.NaN;

            double result = 0;
            Parallel.For(0, A.Data.Length, (n) =>
            {
                result += A.Data[n] * B.Data[n];
            });

            return result;
        }

        public static Vector operator +(Vector A, Vector B)
        {
            if (A.Data.Length != B.Data.Length) return null;

            double[] array = new double[A.Data.Length];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A.Data[n] + B.Data[n];
            });

            return new Vector(A.Rows, A.Columns, array);
        }
        public static Vector operator +(Vector A, double B)
        {
            double[] array = new double[A.Rows * A.Columns];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A.Data[n] + B;
            });

            return new Vector(A.Rows, A.Columns, array);
        }
        public static Vector operator +(double A, Vector B)
        {
            double[] array = new double[B.Rows * B.Columns];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A + B.Data[n];
            });

            return new Vector(B.Rows, B.Columns, array);
        }

        public static Vector operator -(Vector A, Vector B)
        {
            if (A.Data.Length != B.Data.Length) return null;

            double[] array = new double[A.Rows * A.Columns];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A.Data[n] - B.Data[n];
            });

            return new Vector(A.Rows, A.Columns, array);
        }
        public static Vector operator -(Vector A, double B)
        {
            double[] array = new double[A.Data.Length];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A.Data[n] - B;
            });

            return new Vector(A.Rows, A.Columns, array);
        }
        public static Vector operator -(double A, Vector B)
        {
            double[] array = new double[B.Data.Length];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A - B.Data[n];
            });

            return new Vector(B.Rows, B.Columns, array);
        }

        public static dynamic operator *(Vector A, Vector B)
        {
            if (A.Data.Length != B.Data.Length) return null;
            double[] array;

            if (A.Rows == 1 && B.Columns == 1)
            {
                double result = 0;

                Parallel.For(0, A.Data.Length, (n) =>
                {
                    result += A.Data[n] * B.Data[n];
                });

                return result;
            }
            else if (A.Columns == 1 && B.Rows == 1)
            {
                array = new double[A.Rows * B.Columns];

                Parallel.For(0, array.Length, (n) =>
                {
                    int row = n / B.Columns;
                    int col = n % B.Columns;

                    array[n] = A.Data[row] * B.Data[col];
                });

                return new Matrix(A.Rows, B.Columns, array);
            }

            array = new double[A.Data.Length];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A.Data[n] * B.Data[n];
            });

            return new Vector(A.Rows, A.Columns, array);
        }
        public static Vector operator *(Vector A, double B)
        {
            double[] array = new double[A.Rows * A.Columns];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A.Data[n] * B;
            });

            return new Vector(A.Rows, A.Columns, array);
        }
        public static Vector operator *(double A, Vector B)
        {
            double[] array = new double[B.Rows * B.Columns];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A * B.Data[n];
            });

            return new Vector(B.Rows, B.Columns, array);
        }

        public static Vector operator *(Matrix A, Vector B)
        {
            if (A.Columns != B.Rows || B.Columns != 1) return null;

            double[] array = new double[A.Rows];

            Parallel.For(0, array.Length, (n) =>
            {
                int row = n / B.Columns;
                int col = n % B.Columns;

                double value = 0;
                for (int i = 0; i < A.Columns; i++)
                    value += A.Data[row * A.Columns + i] * B.Data[row];

                array[n] = value;
            });

            return new Vector(A.Rows, B.Columns, array);
        }
        public static Vector operator *(Vector A, Matrix B)
        {
            if (A.Columns != B.Rows || A.Rows != 1) return null;

            double[] array = new double[B.Rows];

            Parallel.For(0, array.Length, (n) =>
            {
                int row = n / B.Columns;
                int col = n % B.Columns;

                double value = 0;
                for (int i = 0; i < B.Rows; i++)
                    value += A.Data[col] * B.Data[row * B.Columns + i];

                array[n] = value;
            });

            return new Vector(A.Rows, B.Columns, array);
        }


        public override string ToString()
        {
            string result = "";

            for (int j = 0; j < Rows; j++)
            {
                for (int i = 0; i < Columns; i++)
                    result += Data[j*Columns + i].ToString("N3") + " ";
                result += "\n";
            }

            return result;
        }
        public string ToString(string format = "N3")
        {
            string result = "";

            for (int j = 0; j < Rows; j++)
            {
                for (int i = 0; i < Columns; i++)
                    result += Data[j * Columns + i].ToString("N3") + " ";
                result += "\n";
            }

            return result;
        }
    }
}
