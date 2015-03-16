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

    public class MatrixMain
    {
        public static void Main()
        {
            Matrix<double> firstMatrix = new Matrix<double>(2, 3);
            Matrix<double> secondMatrix = new Matrix<double>(3, 3);
            FillFirstMatrixMultiplication(firstMatrix);
            FillSecondMatrixMultiplication(secondMatrix);

            Matrix<double> multiplication = firstMatrix * secondMatrix;

            firstMatrix = new Matrix<double>(2, 2);
            secondMatrix = new Matrix<double>(2, 2);
            FillFirstMatrixAddSubstract(firstMatrix);
            FillSecondMatrixAddSubstract(secondMatrix);

            Matrix<double> addition = firstMatrix + secondMatrix;

            Matrix<double> substraction = firstMatrix - secondMatrix;

            Console.WriteLine("Multiplication:\n{0}\nAddition:\n{1}\nSubstraction:\n{2}", multiplication, addition, substraction);
        }

        private static void FillSecondMatrixAddSubstract(Matrix<double> secondMatrix)
        {
            double[,] matrix = new double[,] { { 5, 2 }, { 3, 0 } };
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    secondMatrix[row, col] = matrix[row, col];
                }
            }
        }

        private static void FillFirstMatrixAddSubstract(Matrix<double> firstMatrix)
        {
            double[,] matrix = new double[,] { { 0, 1 }, { 12, 4 } };
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    firstMatrix[row, col] = matrix[row, col];
                }
            }
        }

        private static void FillSecondMatrixMultiplication(Matrix<double> secondMatrix)
        {
            double[,] matrix = new double[,] { { -23.3, 12.14, -5 }, { 10, -1, 0.1 }, { 10, 10, 10 } };
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    secondMatrix[row, col] = matrix[row, col];
                }
            }
        }

        private static void FillFirstMatrixMultiplication(Matrix<double> firstMatrix)
        {
            double[,] matrix = new double[,] { { -23, 12, 10.1 }, { 2.3, -7.4, 49 } };
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    firstMatrix[row, col] = matrix[row, col];
                }
            }
        }
    }
}
