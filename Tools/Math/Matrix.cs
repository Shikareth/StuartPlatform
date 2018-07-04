using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Math
{
    public class Matrix
    {
        public double[] Data { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Matrix(int rows, int columns, double value)
        {
            Data = new double[rows*columns];
            Rows = rows;
            Columns = columns;
            Parallel.For(0, Data.Length, (n) =>
            {
                Data[n] = value;
            });
        }

        public Matrix(int rows, int columns, IEnumerable<double> data)
        {
            Data = new double[rows * columns];
            Rows = rows;
            Columns = columns;
            var array = data.ToArray();
            Parallel.For(0, Data.Length, (n) =>
            {
                Data[n] = array[n];
            });
        }

        public Matrix(Vector3D ix, Vector3D iy, Vector3D iz)
        {
            Data = new double[9];
            Rows = 3;
            Columns = 3;

            Data[0] = ix.X;
            Data[1] = ix.Y;
            Data[2] = ix.Z;

            Data[3] = iy.X;
            Data[4] = iy.Y;
            Data[5] = iy.Z;

            Data[6] = iz.X;
            Data[7] = iz.Y;
            Data[8] = iz.Z;
        }

        public Matrix(Vector3D ix, Vector3D iy)
        {
            Data = new double[4];
            Rows = 2;
            Columns = 2;

            Data[0] = ix.X;
            Data[1] = ix.Y;

            Data[2] = iy.X;
            Data[3] = iy.Y;
        }

        public Matrix(double angle)
        {
            Data = new double[4];
            Rows = 2;
            Columns = 2;

            Data[0] = System.Math.Cos(angle);
            Data[1] = -System.Math.Sin(angle);

            Data[2] = System.Math.Cos(angle);
            Data[3] = System.Math.Sin(angle);
        }

        public Matrix(Vector3D axis, double angle)
        {
            Data = new double[9];
            Rows = 3;
            Columns = 3;

            var A = System.Math.Cos(angle);
            var B = 1 - System.Math.Cos(angle);
            var C = System.Math.Sin(angle);

            Data[0] = A + System.Math.Pow(axis.X, 2) * B;
            Data[1] = axis.X * axis.Y * B - axis.Z * C;
            Data[2] = axis.X * axis.Z * B + axis.Y * C;

            Data[3] = axis.Y * axis.X * B + axis.Z * C;
            Data[4] = A + System.Math.Pow(axis.Y, 2) * B;
            Data[5] = axis.Y * axis.Z * B - axis.X * C;

            Data[6] = axis.Z * axis.X * B - axis.Y * C;
            Data[7] = axis.Z * axis.Y * B + axis.X * C;
            Data[8] = A + System.Math.Pow(axis.Z, 2) * B;

        }

        /// <image url="$.(ProjectDir)\Images\EulerAngles.PNG"/>
        public static Matrix RotationMatrixXZX(double alpha, double beta, double gamma)
        {
            double[] data = new double[9];

            var cx = System.Math.Cos(alpha);
            var sx = System.Math.Sin(alpha);
            var cy = System.Math.Cos(beta);
            var sy = System.Math.Sin(beta);
            var cz = System.Math.Cos(gamma);
            var sz = System.Math.Sin(gamma);

            data[0] = cy;
            data[1] = -cz * sy;
            data[2] = sy*sz;

            data[3] = cx * sy;
            data[4] = cx * cy * cz - sx * sz;
            data[5] = -cz * sx - cx * cy * sz;

            data[6] = sx * sy;
            data[7] = cx * sz + cy * cz * sx;
            data[8] = cx * cz - cy * sx * sz;

            return new Matrix(3, 3, data);
        }
        public static Matrix RotationMatrixXZY(double alpha, double beta, double gamma)
        {
            double[] data = new double[9];

            var cx = System.Math.Cos(alpha);
            var sx = System.Math.Sin(alpha);
            var cy = System.Math.Cos(beta);
            var sy = System.Math.Sin(beta);
            var cz = System.Math.Cos(gamma);
            var sz = System.Math.Sin(gamma);

            data[0] = cy * cz;
            data[1] = -sy;
            data[2] = cy * sz;

            data[3] = sx * sz + cx * cz * sy;
            data[4] = cx * cy;
            data[5] = cx * sy * sz - cz * sx;

            data[6] = cz * sx * sy - cx * sz;
            data[7] = cy * sx;
            data[8] = cx * cz + sx * sy * sz;

            return new Matrix(3, 3, data);
        }
        public static Matrix RotationMatrixXYX(double alpha, double beta, double gamma)
        {
            double[] data = new double[9];

            var cx = System.Math.Cos(alpha);
            var sx = System.Math.Sin(alpha);
            var cy = System.Math.Cos(beta);
            var sy = System.Math.Sin(beta);
            var cz = System.Math.Cos(gamma);
            var sz = System.Math.Sin(gamma);

            data[0] = cy;
            data[1] = sy * sz;
            data[2] = cz * sy;

            data[3] = sx * sy;
            data[4] = cx * cz - cy * sx * sz;
            data[5] = -cx * sz - cy * cz * sx;

            data[6] = -cx * sy;
            data[7] = cz * sx + cx * cy * sz;
            data[8] = cx * cy * cz - sx * sz;

            return new Matrix(3, 3, data);
        }
        public static Matrix RotationMatrixXYZ(double alpha, double beta, double gamma)
        {
            double[] data = new double[9];

            var cx = System.Math.Cos(alpha);
            var sx = System.Math.Sin(alpha);
            var cy = System.Math.Cos(beta);
            var sy = System.Math.Sin(beta);
            var cz = System.Math.Cos(gamma);
            var sz = System.Math.Sin(gamma);

            data[0] = cy * cz;
            data[1] = -cy * sz;
            data[2] = sy;

            data[3] = cx * sz + cz * sx * sy;
            data[4] = cx * cz - sx * sy * sz;
            data[5] = -cy * sx;

            data[6] = sx * sz - cx * cz * sy;
            data[7] = cz * sx + cx * sy * sz;
            data[8] = cx * cy;

            return new Matrix(3, 3, data);
        }
        public static Matrix RotationMatrixYXY(double alpha, double beta, double gamma)
        {
            double[] data = new double[9];

            var cx = System.Math.Cos(alpha);
            var sx = System.Math.Sin(alpha);
            var cy = System.Math.Cos(beta);
            var sy = System.Math.Sin(beta);
            var cz = System.Math.Cos(gamma);
            var sz = System.Math.Sin(gamma);

            data[0] = cx * cz - cy * sx * sz;
            data[1] = sx * sy;
            data[2] = cx * sz + cy * cz * sx;

            data[3] = sy * sz;
            data[4] = cy;
            data[5] = -cz * sy;

            data[6] = -cz * sx - cx * cy * sz;
            data[7] = cx * sy;
            data[8] = cx * cy * cz - sx * sz;

            return new Matrix(3, 3, data);
        }
        public static Matrix RotationMatrixYXZ(double alpha, double beta, double gamma)
        {
            double[] data = new double[9];

            var cx = System.Math.Cos(alpha);
            var sx = System.Math.Sin(alpha);
            var cy = System.Math.Cos(beta);
            var sy = System.Math.Sin(beta);
            var cz = System.Math.Cos(gamma);
            var sz = System.Math.Sin(gamma);

            data[0] = cx * cz + sx * sy * sz;
            data[1] = cz * sx * sy - cx * sy;
            data[2] = cy * sx;

            data[3] = cy * sz;
            data[4] = cy * cz;
            data[5] = -sy;

            data[6] = cx * sy * sz - cz * sx;
            data[7] = cx * cz * sy + sx * sz;
            data[8] = cx * cy;

            return new Matrix(3, 3, data);
        }
        public static Matrix RotationMatrixYZY(double alpha, double beta, double gamma)
        {
            double[] data = new double[9];

            var cx = System.Math.Cos(alpha);
            var sx = System.Math.Sin(alpha);
            var cy = System.Math.Cos(beta);
            var sy = System.Math.Sin(beta);
            var cz = System.Math.Cos(gamma);
            var sz = System.Math.Sin(gamma);

            data[0] = cx * cy * cz - sx * sz;
            data[1] = -cx * sy;
            data[2] = cz * sx + cx * cy * sz;

            data[3] = cz * sy;
            data[4] = cy;
            data[5] = sy * sz;

            data[6] = -cx * sz - cy * cz * sx;
            data[7] = sx * sy;
            data[8] = cx * cz - cy * sx * sz;

            return new Matrix(3, 3, data);
        }
        public static Matrix RotationMatrixYZX(double alpha, double beta, double gamma)
        {
            double[] data = new double[9];

            var cx = System.Math.Cos(alpha);
            var sx = System.Math.Sin(alpha);
            var cy = System.Math.Cos(beta);
            var sy = System.Math.Sin(beta);
            var cz = System.Math.Cos(gamma);
            var sz = System.Math.Sin(gamma);

            data[0] = cx * cy;
            data[1] = sx * sz - cx * cz * sy;
            data[2] = cz * sx + cx * sy * sz;

            data[3] = sy;
            data[4] = cy * cz;
            data[5] = -cy * sz;

            data[6] = -cy * sx;
            data[7] = cx * sz + cz * sx * sy;
            data[8] = cx * cz - sx * sy * sz;

            return new Matrix(3, 3, data);
        }
        public static Matrix RotationMatrixZYZ(double alpha, double beta, double gamma)
        {
            double[] data = new double[9];

            var cx = System.Math.Cos(alpha);
            var sx = System.Math.Sin(alpha);
            var cy = System.Math.Cos(beta);
            var sy = System.Math.Sin(beta);
            var cz = System.Math.Cos(gamma);
            var sz = System.Math.Sin(gamma);

            data[0] = cx * cy * cz - sx * sz;
            data[1] = -cz * sx - cx * cy * sz;
            data[2] = cx * cy;

            data[3] = cx * sz + cy * cz * sx;
            data[4] = cx * cz - cy * cz * sx;
            data[5] = sx * sy;

            data[6] = -cz * sy;
            data[7] = sy * sz;
            data[8] = cy;

            return new Matrix(3, 3, data);
        }
        public static Matrix RotationMatrixZYX(double alpha, double beta, double gamma)
        {
            double[] data = new double[9];

            var cx = System.Math.Cos(alpha);
            var sx = System.Math.Sin(alpha);
            var cy = System.Math.Cos(beta);
            var sy = System.Math.Sin(beta);
            var cz = System.Math.Cos(gamma);
            var sz = System.Math.Sin(gamma);

            data[0] = cx * cy;
            data[1] = cx * sy * sz - cz * sx;
            data[2] = sx * sy + cx * cz * sy;

            data[3] = cy * sx;
            data[4] = cx * cz + sx * sy * sz;
            data[5] = cz * sx * sy - cx * sz;

            data[6] = -sy;
            data[7] = cy * sz;
            data[8] = cy * cz;

            return new Matrix(3, 3, data);
        }
        public static Matrix RotationMatrixZXZ(double alpha, double beta, double gamma)
        {
            double[] data = new double[9];

            var cx = System.Math.Cos(alpha);
            var sx = System.Math.Sin(alpha);
            var cy = System.Math.Cos(beta);
            var sy = System.Math.Sin(beta);
            var cz = System.Math.Cos(gamma);
            var sz = System.Math.Sin(gamma);

            data[0] = cx * cz - cy * sx * sz;
            data[1] = -cx * sz - cy * cz * sx;
            data[2] = sx * sy;

            data[3] = cz * sx + cx * cy * sz;
            data[4] = cx * cy * cz - sx * sz;
            data[5] = -cx * sy;

            data[6] = sy * sz;
            data[7] = cz * sy;
            data[8] = cy;

            return new Matrix(3, 3, data);
        }
        public static Matrix RotationMatrixZXY(double alpha, double beta, double gamma)
        {
            double[] data = new double[9];

            var cx = System.Math.Cos(alpha);
            var sx = System.Math.Sin(alpha);
            var cy = System.Math.Cos(beta);
            var sy = System.Math.Sin(beta);
            var cz = System.Math.Cos(gamma);
            var sz = System.Math.Sin(gamma);

            data[0] = cx * cz - sx * sy * sz;
            data[1] = -cy * sx;
            data[2] = cx * sz + cz * sx * sy;

            data[3] = cz * sx + cx * sy * sz;
            data[4] = cx * cy;
            data[5] = sx * sz - cx * cz * sy;

            data[6] = -cy * sz;
            data[7] = sy;
            data[8] = cy * cz;

            return new Matrix(3, 3, data);
        }

        public Matrix Transposed()
        {
            double[] array = new double[Data.Length];
            Parallel.For(0, Data.Length, (n) =>
            {
                int row = n / Columns;
                int col = n % Columns;

                array[n] = Data[col * Rows + row];
            });

            return new Matrix(Columns, Rows, array);
        }
        public void Transpose()
        {
            double[] array = new double[Data.Length];
            Parallel.For(0, Data.Length, (n) =>
            {
                int row = n / Columns;
                int col = n % Columns;

                array[n] = Data[col * Rows + row];
            });

            Data = array;
            var columns = Columns;
            Columns = Rows;
            Rows = Columns;
        }

        public Matrix Minor(int row, int column)
        {
            double[] array = new double[(Rows - 1) * (Columns - 1)];

            Parallel.For(0, array.Length, (n) =>
            {
                int r = n / (Columns - 1);
                int c = n % (Columns - 1);

                if (r >= row) r++;
                if (c >= column) c++;

                array[n] = Data[r * Columns + c];
            });

            return new Matrix(Rows-1, Columns-1, array);
        }

        //TODO finish determinant for size > 3
        public double Det()
        {
            if (Rows != Columns || Rows < 2) return double.NaN;
            int size = Columns;

            double det = 0;

            switch (size)
            {
                case 2:
                    det = Data[0] * Data[3] - Data[1] * Data[2];
                    break;

                case 3:
                    det = Data[0] * Data[4] * Data[8] +
                        Data[1] * Data[5] * Data[6] +
                        Data[2] * Data[3] * Data[7] -
                        Data[6] * Data[4] * Data[2] -
                        Data[7] * Data[5] * Data[0] -
                        Data[8] * Data[3] * Data[1];
                    break;
                default:
                    Parallel.For(0, Columns, (n) =>
                    {
                        int r = n / Columns;
                        int c = n % Columns;





                    });
                    det = double.NaN;
                    break;
            }

            return det;
        }

        //TODO check if correct
        public Matrix[] LU_Doolittle()
        {
            if (Rows != Columns) return null;

            double[] L = new double[Data.Length];
            double[] U = new double[Data.Length];


            for (int i = 0; i < Columns; i++)
            {

                // Upper triangular
                for (int k = 0; k < Columns; k++)
                {
                    // SUM{ L(i, j) * U(j, k) }
                    double sum = 0;
                    for (int j = 0; j < i; j++)
                        sum += L[i * Columns + j] * U[j * Columns + k];

                    // U(i, k) =
                    U[i * Columns + k] = Data[i * Columns + k] - sum;
                }

                // Lower triangular
                for (int k = 0; k < Columns; k++)
                {
                    if (i == k)
                        L[i*Columns + i] = 1;
                    else
                    {
                        // SUM{ L(k, j) * U(j, i) }
                        double sum = 0;
                        for (int j = 0; j < i; j++)
                            sum += L[k * Columns + j] * U[j * Columns + i];

                        // L(k, i) =
                        U[k * Columns + i] = (Data[k * Columns + i] - sum) / U[i * Columns + i];
                    }
                }
            }

            return new Matrix[2] { new Matrix(Columns, Columns, L), new Matrix(Columns, Columns, U) };
        }

        //TODO SVD algorithms
        public SVDArgs SVD_Householder()
        {
            Matrix B = new Matrix(Rows, Columns, Data);
            Matrix U = new Matrix(Rows, Columns, 0);
            Matrix V = new Matrix(Columns, Columns, 0);

            for (int k = 1; k < Columns; k++)
            {
                double[] q = new double[Data.Length];

                for (int n = 0; n < Rows; n++)
                {
                    if (n < k - 1)
                        B.Data[n * Columns + k] = 0;
                }
            }



            return new SVDArgs();
        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (A.Rows != B.Rows || A.Columns != B.Columns) return null;

            double[] array = new double[A.Rows * A.Columns];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A.Data[n] + B.Data[n];
            });

            return new Matrix(A.Rows, A.Columns, array);
        }
        public static Matrix operator +(Matrix A, double B)
        {
            double[] array = new double[A.Rows * A.Columns];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A.Data[n] + B;
            });

            return new Matrix(A.Rows, A.Columns, array);
        }
        public static Matrix operator +(double A, Matrix B)
        {
            double[] array = new double[B.Rows * B.Columns];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A + B.Data[n];
            });

            return new Matrix(B.Rows, B.Columns, array);
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            if (A.Rows != B.Rows || A.Columns != B.Columns) return null;

            double[] array = new double[A.Rows * A.Columns];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A.Data[n] - B.Data[n];
            });

            return new Matrix(A.Rows, A.Columns, array);
        }
        public static Matrix operator -(Matrix A, double B)
        {
            double[] array = new double[A.Rows * A.Columns];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A.Data[n] - B;
            });

            return new Matrix(A.Rows, A.Columns, array);
        }
        public static Matrix operator -(double A, Matrix B)
        {
            double[] array = new double[B.Rows * B.Columns];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A - B.Data[n];
            });

            return new Matrix(B.Rows, B.Columns, array);
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.Columns != B.Rows) return null;

            double[] array = new double[A.Rows * B.Columns];

            Parallel.For(0, array.Length, (n) =>
            {
                int row = n / B.Columns;
                int col = n % B.Columns;

                double value = 0;
                for (int i = 0; i < A.Columns; i++)
                    value += A.Data[row * A.Columns + i] * B.Data[i * B.Columns + col];

                array[n] = value;
            });

            return new Matrix(A.Rows, B.Columns, array);
        }
        public static Matrix operator *(Matrix A, double B)
        {
            double[] array = new double[A.Rows * A.Columns];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A.Data[n] * B;
            });

            return new Matrix(A.Rows, A.Columns, array);
        }
        public static Matrix operator *(double A, Matrix B)
        {
            double[] array = new double[B.Rows * B.Columns];

            Parallel.For(0, array.Length, (n) =>
            {
                array[n] = A * B.Data[n];
            });

            return new Matrix(B.Rows, B.Columns, array);
        }

        public static Vector3D operator *(Matrix A, Vector3D V)
        {
            if (A.Columns != A.Rows || A.Columns != 3) return null;

            double[] array = new double[3];

            Parallel.For(0, A.Data.Length, (n) =>
            {
                int row = n / A.Columns;
                int col = n % A.Columns;

                double value = 0;
                for (int i = 0; i < 3; i++)
                    value += A.Data[row * A.Columns + i] * V.Data[i];

                array[row] = value;
            });

            return new Vector3D(array);
        }
        public static Vector3D operator *(Vector3D V, Matrix A)
        {
            if (A.Columns != A.Rows || A.Columns != 3) return null;

            double[] array = new double[3];

            Parallel.For(0, A.Data.Length, (n) =>
            {
                int row = n / A.Columns;
                int col = n % A.Columns;

                double value = 0;
                for (int i = 0; i < 3; i++)
                    value += A.Data[row * A.Columns + i] * V.Data[i];

                array[row] = value;
            });

            return new Vector3D(array);
        }

        public static Vector2D operator *(Matrix A, Vector2D V)
        {
            if (A.Columns != A.Rows || A.Columns != 2) return null;

            double[] array = new double[3];

            Parallel.For(0, A.Data.Length, (n) =>
            {
                int row = n / A.Columns;
                int col = n % A.Columns;

                double value = 0;
                for (int i = 0; i < 3; i++)
                    value += A.Data[row * A.Columns + i] * V.Data[i];

                array[row] = value;
            });

            return new Vector2D(array);
        }
        public static Vector2D operator *(Vector2D V, Matrix A)
        {
            if (A.Columns != A.Rows || A.Columns != 2) return null;

            double[] array = new double[2];

            Parallel.For(0, A.Data.Length, (n) =>
            {
                int row = n / A.Columns;
                int col = n % A.Columns;

                double value = 0;
                for (int i = 0; i < 2; i++)
                    value += A.Data[row * A.Columns + i] * V.Data[i];

                array[row] = value;
            });

            return new Vector2D(array);
        }

        public static Matrix I(int size)
        {
            double[] data = new double[size * size];
            Parallel.For(0, data.Length, (n) => { 
                if (n % size == n / size) data[n] = 1;
                else data[n] = 0;
            });

            return new Matrix(size, size, data);
        }
        public static Matrix I(int rows, int columns)
        {
            double[] data = new double[rows * columns];
            Parallel.For(0, data.Length, (n) => {
                if (n % columns == n / columns) data[n] = 1;
                else data[n] = 0;
            });

            return new Matrix(rows, columns, data);
        }

        public override string ToString()
        {
            string matrix = string.Empty;

            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                    matrix += Data[y * Columns + x].ToString("N3") + " ";

                matrix.TrimEnd(' ');
                matrix += "\n";
            }

            return matrix;
        }
        public string ToString(string format = "E3")
        {
            string matrix = string.Empty;

            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                    matrix += Data[y * Columns + x].ToString(format) + " ";

                matrix.TrimEnd(' ');
                matrix += "\n";
            }

            return matrix;
        }

        public class SVDArgs
        {
            Matrix U { get; set; }
            Matrix E { get; set; }
            Matrix V { get; set; }
        }
    }
}
