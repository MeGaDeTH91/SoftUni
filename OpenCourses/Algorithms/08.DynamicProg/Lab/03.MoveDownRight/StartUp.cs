namespace _03.MoveDownRight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int[][] matrix;
        private static int[][] dpMatrix;
        private static int rowCount;
        private static int colCount;
        private static List<string> result = new List<string>();

        public static void Main()
        {
            ReadInputAndInitialize();
            GenerateDPMatrix();

            RetrievePath();

            Console.WriteLine(string.Join(" ", result));
        }

        private static void RetrievePath()
        {
            int row = rowCount - 1;
            int col = colCount - 1;

            while (row != 0 || col != 0)
            {
                string currentLocation = $"[{row}, {col}]";

                result.Add(currentLocation);

                if(col - 1 < 0)
                {
                    row--;
                    continue;
                }
                if(row - 1 < 0)
                {
                    col--;
                    continue;
                }
                int goLeft = dpMatrix[row][col - 1];
                int goUp = dpMatrix[row - 1][col];

                if (goUp > goLeft)
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }
            result.Add("[0, 0]");

            result.Reverse();
        }

        private static void GenerateDPMatrix()
        {
            dpMatrix[0][0] = matrix[0][0];

            //Generate first row
            for (int col = 1; col < colCount; col++)
            {
                dpMatrix[0][col] = dpMatrix[0][col - 1] + matrix[0][col];
            }

            //Generate first column
            for (int row = 1; row < rowCount; row++)
            {
                dpMatrix[row][0] = dpMatrix[row - 1][0] + matrix[row][0];
            }

            //Generate the rest
            for (int row = 1; row < rowCount; row++)
            {
                for (int col = 1; col < colCount; col++)
                {
                    int upperElement = dpMatrix[row - 1][col];
                    int leftElement = dpMatrix[row][col - 1];

                    if (upperElement > leftElement)
                    {
                        dpMatrix[row][col] = dpMatrix[row - 1][col] + matrix[row][col];
                    }
                    else
                    {
                        dpMatrix[row][col] = dpMatrix[row][col - 1] + matrix[row][col];
                    }
                }
            }
        }

        private static void ReadInputAndInitialize()
        {
            rowCount = int.Parse(Console.ReadLine());
            colCount = int.Parse(Console.ReadLine());

            matrix = new int[rowCount][];
            dpMatrix = new int[rowCount][];

            for (int row = 0; row < rowCount; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                dpMatrix[row] = new int[colCount];
            }
        }
    }
}
