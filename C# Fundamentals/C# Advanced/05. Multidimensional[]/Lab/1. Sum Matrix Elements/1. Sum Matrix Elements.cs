using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputBorders = Console.ReadLine()
                                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            int rowsCount = inputBorders[0];
            int colsCount = inputBorders[1];

            int[,] matrix = new int[rowsCount, colsCount];

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

            int sum = 0;

            foreach (var m in matrix)
            {
                sum += m;
            }

            Console.WriteLine(rowsCount);
            Console.WriteLine(colsCount);
            Console.WriteLine($"{sum} ");
        }
    }
}
