namespace _02.AreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static char[][] matrix;
        private static bool[][] visited;
        private static int rowCount;
        private static int colCount;
        private static SortedDictionary<char, int> counts;

        public static void Main()
        {
            ReadInputMatrix();

            TraverseMatrix();

            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine($"Areas: {counts.Sum(x => x.Value)}");

            foreach (var area in counts)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void TraverseMatrix()
        {
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (!visited[row][col])
                    {
                        char currentSymbol = matrix[row][col];

                        if (!counts.ContainsKey(currentSymbol))
                        {
                            counts[currentSymbol] = 0;
                        }
                        counts[currentSymbol]++;

                        DFS(row, col, currentSymbol);
                    }
                }
            }
        }

        private static void DFS(int row, int col, char prevSymbol)
        {
            if(IsOutside(row, col) || visited[row][col])
            {
                return;
            }

            char currentSymbol = matrix[row][col];
            if(currentSymbol != prevSymbol)
            {
                return;
            }

            visited[row][col] = true;

            DFS(row - 1, col, currentSymbol); // Up
            DFS(row + 1, col, currentSymbol); // Down
            DFS(row, col + 1, currentSymbol); // Right
            DFS(row, col - 1, currentSymbol); // Left
        }

        private static bool IsOutside(int row, int col)
        {
            return row < 0 || row >= rowCount || col < 0 || col >= colCount;
        }

        private static void ReadInputMatrix()
        {
            rowCount = int.Parse(Console.ReadLine());

            matrix = new char[rowCount][];
            visited = new bool[rowCount][];
            counts = new SortedDictionary<char, int>();

            for (int i = 0; i < rowCount; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
                colCount = matrix[i].Length;
                visited[i] = new bool[colCount];
            }
        }
    }
}
