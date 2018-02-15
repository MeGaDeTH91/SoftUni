using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Crossfire_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimension = Console.ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            int rowCount = matrixDimension[0];
            int colCount = matrixDimension[1];

            int[][] matrix = new int[rowCount][];

            FillMatrix(matrix, rowCount, colCount);

            string command;
            while ((command = Console.ReadLine()) != "Nuke it from orbit")
            {
                int[] nukeParams = command
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

                int impactRow = nukeParams[0];
                int impactCol = nukeParams[1];
                int radius = nukeParams[2];

                CrossFire(ref matrix, impactRow, impactCol, radius);

                //ArrangeElements(matrix);
            }
            

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var m in matrix)
            {
                Console.WriteLine(string.Join(" ", m));
            }
        }

        private static void CrossFire(ref int[][] matrix, int bombRow, int bombCol, int bombRadius)
        {
            //left and right
            for (int rowIndex = bombRow - bombRadius; rowIndex <= bombRow + bombRadius; rowIndex++)
            {
                if (AreIndexesValid(rowIndex, bombCol, matrix))
                {
                    matrix[rowIndex][bombCol] = -1;
                }
            }

            //up and down
            for (int colIndex = bombCol - bombRadius; colIndex <= bombCol + bombRadius; colIndex++)
            {
                if (AreIndexesValid(bombRow, colIndex, matrix))
                {
                    matrix[bombRow][colIndex] = -1;
                }
            }

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                if (matrix[rowIndex].Any(c => c == -1))
                {
                    matrix[rowIndex] = matrix[rowIndex].Where(n => n > 0).ToArray();
                }

                if (matrix[rowIndex].Length < 1)
                {
                    matrix = matrix.Take(rowIndex).Concat(matrix.Skip(rowIndex + 1)).ToArray();
                    rowIndex--;
                }
            }
        }

        private static bool AreIndexesValid(int row, int col, int[][] matrix)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static void FillMatrix(int[][] matrix, int rowCount, int colCount)
        {
            for (int rows = 0; rows < rowCount; rows++)
            {
                matrix[rows] = new int[colCount];
                for (int cols = 0; cols < colCount; cols++)
                {
                    matrix[rows][cols] = rows * colCount + cols + 1;
                }
            }
        }
    }
}
