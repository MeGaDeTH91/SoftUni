using System;
using System.Linq;

namespace _4._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rectSizes = Console.ReadLine()
                              .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();

            int rowCount = rectSizes[0];
            int colCount = rectSizes[1];

            int[,] matrix = new int[rowCount, colCount];

            int maxSum = 0;
            int[,] resultMatrix = new int[3, 3];

            int rowIndex = 0;
            int colIndex = 0;
                        
            for (int rows = 0; rows < rowCount; rows++)
            {
                int[] inputLine = Console.ReadLine()
                                  .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToArray();

                for (int col = 0; col < colCount; col++)
                {
                    matrix[rows, col] = inputLine[col];
                }
            }

            for (int rows = 0; rows < rowCount - 2; rows++)
            {
                for (int cols = 0; cols < colCount - 2; cols++)
                {
                    int tempSum = matrix[rows, cols] + matrix[rows, cols + 1]
                                + matrix[rows, cols + 2] + matrix[rows + 1, cols]
                                + matrix[rows + 1, cols + 1] + matrix[rows + 1, cols + 2]
                                + matrix[rows + 2, cols] + matrix[rows + 2, cols + 1]
                                + matrix[rows + 2, cols + 2];

                    if(tempSum > maxSum)
                    {
                        maxSum = tempSum;
                        rowIndex = rows;
                        colIndex = cols;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int rows = 0; rows < 3; rows++)
            {
                for (int cols = 0; cols < 3; cols++)
                {
                    Console.Write($"{matrix[rowIndex + rows, colIndex + cols]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
