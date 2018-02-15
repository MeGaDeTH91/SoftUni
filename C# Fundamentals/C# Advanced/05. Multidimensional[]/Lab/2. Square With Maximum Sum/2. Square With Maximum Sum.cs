using System;
using System.Linq;

namespace _2._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            int rowsCount = matrixSizes[0];
            int colsCount = matrixSizes[1];

            int[,] matrix = new int[rowsCount, colsCount];

            int[,] resultMatrix = new int[2, 2];

            int sum = 0;

            for (int rows = 0; rows < rowsCount; rows++)
            {
                int[] rowInput = Console.ReadLine()
                                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                for (int cols = 0; cols < colsCount; cols++)
                {
                    matrix[rows, cols] = rowInput[cols];
                }
            }

            
            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {

                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    var tempSum = matrix[rows, cols] + matrix[rows, cols + 1] +
                                  matrix[rows + 1, cols] + matrix[rows + 1, cols + 1];

                    if(tempSum > sum)
                    {
                        sum = tempSum;
                        resultMatrix[0, 0] = matrix[rows, cols];
                        resultMatrix[0, 1] = matrix[rows, cols + 1];
                        resultMatrix[1, 0] = matrix[rows + 1, cols];
                        resultMatrix[1, 1] = matrix[rows + 1, cols + 1];
                    }
                }
            }

            for (int rows = 0; rows < resultMatrix.GetLength(0); rows++)
            {

                for (int cols = 0; cols < resultMatrix.GetLength(1); cols++)
                {
                    Console.Write($"{resultMatrix[rows, cols]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(sum);
        }
    }
}
