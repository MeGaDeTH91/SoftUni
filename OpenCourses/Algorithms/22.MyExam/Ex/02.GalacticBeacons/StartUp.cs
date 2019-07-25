namespace _02.GalacticBeacons
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static char[][] initialMatrix;
        private static bool[][] visited;
        private static int pathCounter = 0;
        private static bool isFound = false;

        public static void Main()
        {
            int rowCount = int.Parse(Console.ReadLine());
            int colCount = 0;

            int rowStart = 0;
            int colStart = 0;

            initialMatrix = new char[rowCount][];
            visited = new bool[rowCount][];

            for (int row = 0; row < rowCount; row++)
            {
                initialMatrix[row] = Console.ReadLine()
                    .ToCharArray();

                colCount = initialMatrix[row].Length;
                visited[row] = new bool[colCount];

                if (initialMatrix[row].Contains('3'))
                {
                    rowStart = row;
                    colStart = Array.FindIndex(initialMatrix[row], x => x == '3');
                }
            }

            CheckMatrix(rowStart, colStart, rowCount, colCount);

            PrintResult();
        }

        private static void CheckMatrix(int row, int col, int rowCount, int colCount)
        {
            if (isFound)
            {
                return;
            }
            if (!InBorder(row, col, rowCount, colCount) || visited[row][col])
            {
                return;
            }

            if(initialMatrix[row][col] == '1')
            {
                return;
            }

            if(initialMatrix[row][col] == '5')
            {
                isFound = true;
                return;
            }

            visited[row][col] = true;

            int count = 0;
            count += CheckIfOption(row, col + 1, rowCount, colCount);
            count += CheckIfOption(row + 1, col, rowCount, colCount);
            count += CheckIfOption(row, col - 1, rowCount, colCount);
            count += CheckIfOption(row - 1, col, rowCount, colCount);

            if (count > 1)
            {
                pathCounter++;
            }

            CheckMatrix(row, col + 1, rowCount, colCount); // Go Right
            CheckMatrix(row + 1, col, rowCount, colCount); // Go Down
            CheckMatrix(row, col - 1, rowCount, colCount); // Go Left
            CheckMatrix(row - 1, col, rowCount, colCount); // Go Up
        }

        private static int CheckIfOption(int row, int col, int rowCount, int colCount)
        {
            if(!InBorder(row, col, rowCount, colCount))
            {
                return 0;
            }
            if(initialMatrix[row][col] != '1' && !visited[row][col])
            {
                return 1;
            }
            return 0;
        }

        private static bool InBorder(int row, int col, int rowCount, int colCount)
        {
            return row >= 0 && row < rowCount && col >= 0 && col < colCount;
        }

        private static void PrintResult()
        {
            Console.WriteLine(pathCounter);
        }
    }
}
