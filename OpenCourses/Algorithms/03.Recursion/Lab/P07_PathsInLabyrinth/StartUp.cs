using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_PathsInLabyrinth
{
    class StartUp
    {
        static char[][] labyrinth;
        static List<char> path = new List<char>();

        static void Main(string[] args)
        {
            FillLabyrinth();

            FindPathInLabyrinth(0, 0, 'S');
        }

        private static void FindPathInLabyrinth(int row, int col, char direction)
        {
            if (!IsInBounds(row, col))
            {
                return;
            }
            path.Add(direction);

            if(IsValidExit(row, col))
            {
                PrintPath();
            }
            else if(!IsVisited(row, col) && IsFree(row, col))
            {
                MarkCell(row, col);
                //Go Right!
                FindPathInLabyrinth(row, col + 1, 'R');
                //Go Left!
                FindPathInLabyrinth(row, col - 1, 'L');
                //Go Down!
                FindPathInLabyrinth(row + 1, col, 'D');
                //Go Up!
                FindPathInLabyrinth(row - 1, col, 'U');

                UnmarkCell(row, col);
            }
            path.RemoveAt(path.Count - 1);
        }

        private static void UnmarkCell(int row, int col)
        {
            labyrinth[row][col] = '-';
        }

        private static void MarkCell(int row, int col)
        {
            labyrinth[row][col] = 'V';
        }

        private static bool IsFree(int row, int col)
        {
            return labyrinth[row][col] == '-';
        }

        private static bool IsVisited(int row, int col)
        {
            return labyrinth[row][col] == 'V';
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join("", path.Where(x => x != 'S')));
        }

        private static bool IsValidExit(int row, int col)
        {
            return labyrinth[row][col] == 'e';
        }

        private static bool IsInBounds(int row, int col)
        {
            return row < labyrinth.Length && row >= 0 && col < labyrinth[row].Length && col >= 0;
        }

        private static void FillLabyrinth()
        {
            int rowCount = int.Parse(Console.ReadLine());
            int colCount = int.Parse(Console.ReadLine());

            labyrinth = new char[rowCount][];

            for (int row = 0; row < rowCount; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                labyrinth[row] = currentRow;
            }
        }
    }
}
