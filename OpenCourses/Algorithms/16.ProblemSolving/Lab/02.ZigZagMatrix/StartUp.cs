namespace _02.ZigZagMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int[][] matrix;
        private static int[][] sumMatrix;
        private static int[][] prev;
        private static int rowCount;
        private static int colCount;
        private static int maxRow;

        public static void Main()
        {
            ReadInput();

            PopulatePathMatrix();

            PrintResult();
        }

        private static void PopulatePathMatrix()
        {
            for (int  col = 1; col < colCount; col++)
            {
                for (int row = 0; row < rowCount; row++)
                {
                    int previousMax = 0;

                    if (col % 2 != 0)
                    {
                        for (int i = row + 1; i < rowCount; i++)
                        {
                            if(sumMatrix[i][col - 1] > previousMax)
                            {
                                previousMax = sumMatrix[i][col - 1];
                                prev[row][col] = i;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < row; i++)
                        {
                            if (sumMatrix[i][col - 1] > previousMax)
                            {
                                previousMax = sumMatrix[i][col - 1];
                                prev[row][col] = i;
                            }
                        }
                    }
                    sumMatrix[row][col] = previousMax + matrix[row][col];
                }
            }
            GetLastRowIndex();
        }

        private static void GetLastRowIndex()
        {
            int currentRowIndex = -1;
            int globalMax = 0;

            for (int row = 0; row < rowCount; row++)
            {
                if(sumMatrix[row][colCount - 1] > globalMax)
                {
                    globalMax = sumMatrix[row][colCount - 1];
                    currentRowIndex = row;
                }
            }

            maxRow = currentRowIndex;
        }

        private static void PrintResult()
        {
            long sum = 0;
            List<int> result = new List<int>();
            int colIndex = colCount - 1;
            int rowIndex = maxRow;

            while (colIndex >= 0)
            {
                int currentNum = matrix[rowIndex][colIndex];
                sum += currentNum;

                result.Add(currentNum);

                rowIndex = prev[rowIndex][colIndex];
                colIndex--;
            }

            result.Reverse();

            Console.WriteLine($"{sum} = {string.Join(" + ", result)}");
        }

        private static void ReadInput()
        {
            rowCount = int.Parse(Console.ReadLine());
            colCount = int.Parse(Console.ReadLine());

            matrix = new int[rowCount][];
            sumMatrix = new int[rowCount][];
            prev = new int[rowCount][];

            for (int row = 0; row < rowCount; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                sumMatrix[row] = new int[colCount];
                if(row > 0)
                {
                    sumMatrix[row][0] = matrix[row][0];
                }

                prev[row] = new int[colCount];
            }
        }
    }
}
