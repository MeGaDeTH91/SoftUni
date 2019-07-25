namespace _06.ConnectedAreas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static char[][] matrix;
        private static SortedSet<ConnectedArea> areas = new SortedSet<ConnectedArea>();
        private static int areaCounter = 1;

        public static void Main(string[] args)
        {
            int rowCount = int.Parse(Console.ReadLine());
            int colCount = int.Parse(Console.ReadLine());

            matrix = new char[rowCount][];
            ReadMatrix();

            FindAreas();
            PrintResult();
        }

        private static void FindAreas()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    char currentElement = matrix[row][col];
                    if(currentElement != '*' && currentElement != 'v')
                    {
                        ConnectedArea area = new ConnectedArea();
                        area.X = row;
                        area.Y = col;
                        area.Size = TraverseArea(row, col);
                        areas.Add(area);
                        Console.WriteLine();
                    }
                }
            }
        }

        private static int TraverseArea(int row, int col)
        {
            if(!IsInBounds(row, col))
            {
                return 0;
            }
            if(!IsValidCell(row, col))
            {
                return 0;
            }
            matrix[row][col] = 'v';
            int up = TraverseArea(row - 1, col);
            int down = TraverseArea(row + 1, col);
            int left = TraverseArea(row, col - 1);
            int right = TraverseArea(row, col + 1);

            return up + down + left + right + 1;
        }

        private static bool IsValidCell(int row, int col)
        {
            return matrix[row][col] == '-';
        }

        private static bool IsInBounds(int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static void PrintResult()
        {
            Console.WriteLine($"Total areas found: {areas.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, areas));
        }
        
        private static void ReadMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .ToCharArray();
            }
        }

        private class ConnectedArea : IComparable<ConnectedArea>
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Size { get; set; }

            public int CompareTo(ConnectedArea nextArea)
            {
                int result = nextArea.Size.CompareTo(this.Size);
                if(result == 0)
                {
                    result = this.X.CompareTo(nextArea.X);
                }
                if(result == 0)
                {
                    result = this.Y.CompareTo(nextArea.Y);
                }
                return result;
            }
            public override string ToString()
            {
                return $"Area #{areaCounter++} at ({this.X}, {this.Y}), size: {this.Size}";
            }
        }
    }
}
