using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static char[][] matrix;
    private static int allAreasSize = 0;

    static void Main(string[] args)
    {
        SortedSet<ConnectedArea> areas = new SortedSet<ConnectedArea>();

        int rowCount = int.Parse(Console.ReadLine());
        int colCount = int.Parse(Console.ReadLine());

        matrix = GenerateMeMatrixAndRead(rowCount, colCount);

        SearchInMatrix(ref matrix, rowCount, colCount,ref areas);

        int areaNumber = 1;
        foreach (var area in areas)
        {
            area.AreaNumber = areaNumber;
            areaNumber++;
        }

        Console.WriteLine($"Total areas found: {areas.Count}");
        foreach (var area in areas)
        {
            Console.WriteLine(area);
        }
    }

    private static void SearchInMatrix(ref char[][] matrix, int rowCount, int colCount, ref SortedSet<ConnectedArea> areas)
    {
        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                char currentElement = matrix[row][col];
                if (IsCorner(row, col))
                {
                    ConnectedArea addArea = new ConnectedArea(row, col);
                    
                    WalkInConnectedArea(row, col, allAreasSize);
                    int currentSize = CountHowManyCellsAreForThisArea(rowCount, colCount);
                    int newCells = currentSize - allAreasSize;
                    allAreasSize = currentSize;
                    addArea.Size = newCells;
                    
                    areas.Add(addArea);
                }
            }
        }
    }

    private static int CountHowManyCellsAreForThisArea(int rowCount, int colCount)
    {
        int cellCounter = 0;

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < colCount; col++)
            {
                char currentElement = matrix[row][col];
                if(currentElement == 'c')
                {
                    cellCounter++;
                }
            }
        }
        return cellCounter;
    }

    private static bool IsCorner(int row, int col)
    {
        bool isLeftBorder = col - 1 < 0 || matrix[row][col - 1] == '*';
        bool isTopBorder = row - 1 < 0 || matrix[row - 1][col] == '*';
        char cell = matrix[row][col];
        bool cellIsFree = cell != '*' && cell != 'c' && cell != 'v';
        return isLeftBorder && isTopBorder && cellIsFree;
    }

    private static void WalkInConnectedArea(int row, int col, int areaSize)
    {
        if (!IsInBounds(row, col))
        {
            return;
        }
        
        else if (!IsVisited(row, col) && IsFree(row, col))
        {
            MarkCell(row, col);
            //Go Right!
            WalkInConnectedArea(row, col + 1, areaSize + 1);
            //Go Left!
            WalkInConnectedArea(row, col - 1, areaSize + 1);
            //Go Down!
            WalkInConnectedArea(row + 1, col, areaSize + 1);
            //Go Up!
            WalkInConnectedArea(row - 1, col, areaSize + 1);

            UnmarkCell(row, col);
        }
    }

    private static bool IsInBounds(int row, int col)
    {
        return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
    }

    private static void UnmarkCell(int row, int col)
    {
        matrix[row][col] = 'c';
    }

    private static void MarkCell(int row, int col)
    {
        matrix[row][col] = 'v';
    }

    private static bool IsFree(int row, int col)
    {
        bool isItFree = matrix[row][col] != 'v' && matrix[row][col] != '*';
        return isItFree;
    }

    private static bool IsVisited(int row, int col)
    {
        return matrix[row][col] == 'v';
    }

    private static char[][] GenerateMeMatrixAndRead(int rowCount, int colCount)
    {
        char[][] matrix = new char[rowCount][];

        for (int i = 0; i < rowCount; i++)
        {
            matrix[i] = Console.ReadLine().ToCharArray();
        }
        return matrix;
    }
    public class ConnectedArea : IComparable<ConnectedArea>
    {
        public int AreaNumber { get; set; }

        public int Row { get; set; }
        public int Col { get; set; }

        public ConnectedArea(int xPosition, int yPosition)
        {
            this.Row = xPosition;
            this.Col = yPosition;
        }

        public int Size { get; set; }

        public override string ToString()
        {
            return $"Area #{this.AreaNumber} at ({this.Row}, {this.Col}), size: {this.Size}";
        }

        public int CompareTo(ConnectedArea other)
        {
            int result = other.Size.CompareTo(this.Size);
            if (result == 0)
            {
                result = this.Row.CompareTo(other.Row);
            }
            if (result == 0)
            {
                result = this.Col.CompareTo(other.Col);
            }

            return result;
        }
    }
}
