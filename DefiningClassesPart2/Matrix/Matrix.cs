/*Problem 8. Matrix

    Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals).
*/
/*Problem 9. Matrix indexer

    Implement an indexer this[row, col] to access the inner matrix cells.
*/
/*Problem 10. Matrix operations

    Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication.
    Throw an exception when the operation cannot be performed.
    Implement the true operator (check for non-zero elements).
*/

namespace GenericMatrix
{
    using System;
    using System.Text;

    public class Matrix<T>
    {
        private T[,] matrix;
        private int rows;
        private int cols;

        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.matrix = new T[this.Rows, this.Cols];
        }

        // Creates a matrix, consisting of predefined values, passed as a T[,].
        public Matrix(T[,] predefinedMatrix)
        {
            this.matrix = predefinedMatrix;
            this.Rows = this.matrix.GetLength(0);
            this.Cols = this.matrix.GetLength(1);
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Rows", value, "The rows cannot be less than 1.");
                }

                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Cols", value, "The cols cannot be less than 1.");
                }

                this.cols = value;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                this.CheckIndexRange(row, col);
                return this.matrix[row, col];
            }

            set
            {
                this.CheckIndexRange(row, col);
                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
        {
            if (a.Cols != b.Cols || a.Rows != b.Rows)
            {
                throw new Exception("Addition cannot be applied to matrices with different dimensions.");
            }

            Matrix<T> result = new Matrix<T>(a.Rows, a.Cols);
            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < a.Cols; col++)
                {
                    result[row, col] = (dynamic)a[row, col] + b[row, col];
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)
        {
            if (a.Cols != b.Cols || a.Rows != b.Rows)
            {
                throw new Exception("Substraction cannot be applied to matrices with different dimensions.");
            }

            Matrix<T> result = new Matrix<T>(a.Rows, a.Cols);
            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < a.Cols; col++)
                {
                    result[row, col] = (dynamic)a[row, col] - b[row, col];
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            if (a.Cols != b.Rows)
            {
                throw new Exception("The matrices cannot be multiplied.");
            }

            Matrix<T> result = new Matrix<T>(a.Rows, b.Cols);
            dynamic temp;
            for (int matrixRow = 0; matrixRow < result.Rows; matrixRow++)
            {
                for (int matrixCol = 0; matrixCol < result.Cols; matrixCol++)
                {
                    temp = 0;
                    for (int index = 0; index < result.Cols; index++)
                    {
                        temp += (dynamic)a[matrixRow, index] * b[index, matrixCol];
                    }

                    result[matrixRow, matrixCol] = temp;
                }
            }

            return result;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            return OverrideBool(matrix);
        }

        public static bool operator false(Matrix<T> matrix)
        {
            return OverrideBool(matrix);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    result.Append(this.matrix[row, col] + "\t");
                }

                result.AppendLine();
            }

            return result.ToString();
        }

        private static bool OverrideBool(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if (matrix[row, col] != (dynamic)0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void CheckIndexRange(int row, int col)
        {
            if (row < 0 || row >= this.Rows)
            {
                throw new IndexOutOfRangeException(
                    string.Format("The row's value: {0} is out of the bounds of the matrix.", row));
            }

            if (col < 0 || col >= this.Cols)
            {
                throw new IndexOutOfRangeException(
                    string.Format("The col's value: {0} is out of the bounds of the matrix.", col));
            }
        }
    }
}
