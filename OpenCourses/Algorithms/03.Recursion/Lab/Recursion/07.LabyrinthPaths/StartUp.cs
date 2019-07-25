namespace _07.LabyrinthPaths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int rowCount = 0;
        private static int colCount = 0;
        private static char[][] labyrinth;
        private static List<char> directions = new List<char>();

        public static void Main()
        {
            ReadInput();
            FindAllPaths(0, 0, 'S');
        }

        private static void FindAllPaths(int row, int col, char direction)
        {
            if(!IsOutsideLabyrinth(row, col))
            {
                return;
            }

            directions.Add(direction);
            if (IsExit(row, col))
            {
                PrintPathDirections();
            }
            else if(!IsVisited(row, col) && !IsWall(row, col))
            {
                MarkCellVisited(row, col);
                FindAllPaths(row - 1, col, 'U');
                FindAllPaths(row + 1, col, 'D');
                FindAllPaths(row, col - 1, 'L');
                FindAllPaths(row, col + 1, 'R');
                UnmarkCellVisited(row, col);
                
            }
            directions.RemoveAt(directions.Count - 1);
        }

        private static void UnmarkCellVisited(int row, int col)
        {
            labyrinth[row][col] = '-';
        }

        private static bool IsVisited(int row, int col)
        {
            return labyrinth[row][col] == 'v';
        }
        private static bool IsWall(int row, int col)
        {
            return labyrinth[row][col] == '*';
        }

        private static bool IsExit(int row, int col)
        {
            return labyrinth[row][col] == 'e';
        }

        private static void PrintPathDirections()
        {
            Console.WriteLine(string.Join("", directions.Where(x => x != 'S')));
        }

        private static void MarkCellVisited(int row, int col)
        {
            labyrinth[row][col] = 'v';
        }

        private static bool IsOutsideLabyrinth(int row, int col)
        {
            return row >= 0 && row < rowCount && col >= 0 && col < colCount;
        }

        private static void ReadInput()
        {
            rowCount = int.Parse(Console.ReadLine());
            colCount = int.Parse(Console.ReadLine());

            labyrinth = new char[rowCount][];

            for (int row = 0; row < rowCount; row++)
            {
                labyrinth[row] = Console.ReadLine()
                    .ToCharArray();
            }
        }
    }
}
