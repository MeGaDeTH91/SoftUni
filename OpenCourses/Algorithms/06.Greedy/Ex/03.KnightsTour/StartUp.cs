namespace _03.KnightsTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static HashSet<Cell> allCells = new HashSet<Cell>();
        private static int[][] resultChessboard;
        private static int chessboardSize = 0;
        private static int currentStep = 0;

        public static void Main()
        {
            ReadInputAndArrangeBoard();

            MarkVisitingOptions();

            VisitAllCells(0, 0);

            PrintResult();
        }

        private static void PrintResult()
        {
            for (int row = 0; row < chessboardSize; row++)
            {
                for (int col = 0; col < chessboardSize; col++)
                {
                    Console.Write(resultChessboard[row][col].ToString().PadLeft(3) + " ");
                }
                Console.WriteLine();
            }
        }

        private static void VisitAllCells(int row, int col)
        {
            currentStep++;
            resultChessboard[row][col] = currentStep;

            Cell currentCell = allCells.First(x => x.X == row && x.Y == col);
            currentCell.IsVisited = true;

            Cell nextCell = ChooseMeNextCell(currentCell);

            if (allCells.All(x => x.IsVisited))
            {
                return; // last cell
            }

            MarkNewOptions(row, col);

            VisitAllCells(nextCell.X, nextCell.Y);
        }

        private static Cell ChooseMeNextCell(Cell currentCell)
        {
            Cell topRight = allCells.FirstOrDefault(x => x.X == currentCell.X - 2 && x.Y == currentCell.Y + 1);
            Cell topLeft = allCells.FirstOrDefault(x => x.X == currentCell.X - 2 && x.Y == currentCell.Y - 1);
            Cell rightTop = allCells.FirstOrDefault(x => x.X == currentCell.X - 1 && x.Y == currentCell.Y + 2);
            Cell leftTop = allCells.FirstOrDefault(x => x.X == currentCell.X - 1 && x.Y == currentCell.Y - 2);

            Cell botRight = allCells.FirstOrDefault(x => x.X == currentCell.X + 2 && x.Y == currentCell.Y + 1);
            Cell botLeft = allCells.FirstOrDefault(x => x.X == currentCell.X + 2 && x.Y == currentCell.Y - 1);
            Cell rightBot = allCells.FirstOrDefault(x => x.X == currentCell.X + 1 && x.Y == currentCell.Y + 2);
            Cell leftBot = allCells.FirstOrDefault(x => x.X == currentCell.X + 1 && x.Y == currentCell.Y - 2);

            HashSet<Cell> tempList = new HashSet<Cell>()
            {
                rightBot,rightTop,leftBot, leftTop, botRight, topRight, topLeft, botLeft
            };

            Cell theChosenOne = tempList
                .Where(x => x != null && !x.IsVisited)
                .ToList()
                .OrderBy(x => x.Value)
                .FirstOrDefault();

            return theChosenOne;
        }

        private static void MarkNewOptions(int row, int col)
        {
            DecreaseValueIfExisting(row - 1, col - 2);  // Left Up
            DecreaseValueIfExisting(row + 1, col - 2);  // Left Down
            DecreaseValueIfExisting(row - 1, col + 2);  // Right Up
            DecreaseValueIfExisting(row + 1, col + 2); // Right Down
            DecreaseValueIfExisting(row - 2, col - 1);  // Up Left
            DecreaseValueIfExisting(row - 2, col + 1);  // Up Right
            DecreaseValueIfExisting(row + 2, col - 1);  // Down Left
            DecreaseValueIfExisting(row + 2, col + 1);  // Down Right
        }

        private static void DecreaseValueIfExisting(int row, int col)
        {
            if (IsInBounds(row, col))
            {
                Cell cell = allCells.First(x => x.X == row && x.Y == col);

                cell.Value--;
            }
        }

        private static void MarkVisitingOptions()
        {
            for (int row = 0; row < chessboardSize; row++)
            {
                for (int col = 0; col < chessboardSize; col++)
                {
                    int optionsCount = 0;

                    optionsCount += CheckAllOptions(row, col);

                    Cell newCell = new Cell()
                    {
                        X = row,
                        Y = col,
                        Value = optionsCount
                    };

                    allCells.Add(newCell);
                }
            }
        }

        private static int CheckAllOptions(int row, int col)
        {
            int optionsCount = 0;

            optionsCount += CheckIfOption(row - 1, col - 2);  // Left Up
            optionsCount += CheckIfOption(row + 1, col - 2);  // Left Down
            optionsCount += CheckIfOption(row - 1, col + 2);  // Right Up
            optionsCount += CheckIfOption(row + 1, col + 2); // Right Down
            optionsCount += CheckIfOption(row - 2, col - 1);  // Up Left
            optionsCount += CheckIfOption(row - 2, col + 1);  // Up Right
            optionsCount += CheckIfOption(row + 2, col - 1);  // Down Left
            optionsCount += CheckIfOption(row + 2, col + 1);  // Down Right

            return optionsCount;
        }

        private static int CheckIfOption(int row, int col)
        {
            if (IsInBounds(row, col))
            {
                return 1;
            }
            return 0;
        }

        private static void ReadInputAndArrangeBoard()
        {
            chessboardSize = int.Parse(Console.ReadLine());
            resultChessboard = new int[chessboardSize][];

            for (int row = 0; row < chessboardSize; row++)
            {
                resultChessboard[row] = new int[chessboardSize];
            }
        }

        private static bool IsInBounds(int row, int col)
        {
            return row >= 0 && row < chessboardSize && col >= 0 && col < chessboardSize;
        }

        private class Cell
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Value { get; set; }
            public bool IsVisited { get; set; }
        }
    }
}
