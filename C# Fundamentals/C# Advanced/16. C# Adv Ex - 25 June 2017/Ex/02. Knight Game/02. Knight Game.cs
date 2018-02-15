using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());

            string[,] chessBoard = new string[boardSize, boardSize];

            FillChessBoard(ref chessBoard, boardSize);

            int minRemoved = CheckBoard(ref chessBoard, boardSize);

            Console.WriteLine(minRemoved);
        }

        private static int CheckBoard(ref string[,] chessBoard, int boardSize)
        {
            bool numIsEnough = false;

            int knightRemoved = 0;

            while (!numIsEnough)
            {
                List<KnightReach> knightsReach = new List<KnightReach>();

                for (int row = 0; row < boardSize; row++)
                {
                    for (int col = 0; col < boardSize; col++)
                    {
                        if (chessBoard[row, col] == "K")
                        {
                            //Check 2xRight 1xUp
                            if (IsLocationValid(row - 1, col + 2, boardSize) && chessBoard[row - 1, col + 2] == "K")
                            {
                                if (!knightsReach.Any(x => x.RowPosition == row && x.ColPosition == col))
                                {
                                    KnightReach currKnight = new KnightReach
                                    {
                                        RowPosition = row,
                                        ColPosition = col,
                                        ReachNum = 0
                                    };
                                    knightsReach.Add(currKnight);
                                }
                                knightsReach.FirstOrDefault(x => x.RowPosition == row && x.ColPosition == col).ReachNum++;
                            }

                            //Check 2xRight 1xDown
                            if (IsLocationValid(row + 1, col + 2, boardSize) && chessBoard[row + 1, col + 2] == "K")
                            {
                                if (!knightsReach.Any(x => x.RowPosition == row && x.ColPosition == col))
                                {
                                    KnightReach currKnight = new KnightReach
                                    {
                                        RowPosition = row,
                                        ColPosition = col,
                                        ReachNum = 0
                                    };
                                    knightsReach.Add(currKnight);
                                }
                                knightsReach.FirstOrDefault(x => x.RowPosition == row && x.ColPosition == col).ReachNum++;
                            }

                            //Check 2xLeft 1xUp
                            if (IsLocationValid(row - 1, col - 2, boardSize) && chessBoard[row - 1, col - 2] == "K")
                            {
                                if (!knightsReach.Any(x => x.RowPosition == row && x.ColPosition == col))
                                {
                                    KnightReach currKnight = new KnightReach
                                    {
                                        RowPosition = row,
                                        ColPosition = col,
                                        ReachNum = 0
                                    };
                                    knightsReach.Add(currKnight);
                                }
                                knightsReach.FirstOrDefault(x => x.RowPosition == row && x.ColPosition == col).ReachNum++;
                            }

                            //Check 2xLeft 1xDown
                            if (IsLocationValid(row + 1, col - 2, boardSize) && chessBoard[row + 1, col - 2] == "K")
                            {
                                if (!knightsReach.Any(x => x.RowPosition == row && x.ColPosition == col))
                                {
                                    KnightReach currKnight = new KnightReach
                                    {
                                        RowPosition = row,
                                        ColPosition = col,
                                        ReachNum = 0
                                    };
                                    knightsReach.Add(currKnight);
                                }
                                knightsReach.FirstOrDefault(x => x.RowPosition == row && x.ColPosition == col).ReachNum++;
                            }

                            //Check 2xUp 1xRight
                            if (IsLocationValid(row - 2, col + 1, boardSize) && chessBoard[row - 2, col + 1] == "K")
                            {
                                if (!knightsReach.Any(x => x.RowPosition == row && x.ColPosition == col))
                                {
                                    KnightReach currKnight = new KnightReach
                                    {
                                        RowPosition = row,
                                        ColPosition = col,
                                        ReachNum = 0
                                    };
                                    knightsReach.Add(currKnight);
                                }
                                knightsReach.FirstOrDefault(x => x.RowPosition == row && x.ColPosition == col).ReachNum++;
                            }

                            //Check 2xUp 1xLeft
                            if (IsLocationValid(row - 2, col - 1, boardSize) && chessBoard[row - 2, col - 1] == "K")
                            {
                                if (!knightsReach.Any(x => x.RowPosition == row && x.ColPosition == col))
                                {
                                    KnightReach currKnight = new KnightReach
                                    {
                                        RowPosition = row,
                                        ColPosition = col,
                                        ReachNum = 0
                                    };
                                    knightsReach.Add(currKnight);
                                }
                                knightsReach.FirstOrDefault(x => x.RowPosition == row && x.ColPosition == col).ReachNum++;
                            }

                            //Check 2xDown 1xRight
                            if (IsLocationValid(row + 2, col + 1, boardSize) && chessBoard[row + 2, col + 1] == "K")
                            {
                                if (!knightsReach.Any(x => x.RowPosition == row && x.ColPosition == col))
                                {
                                    KnightReach currKnight = new KnightReach
                                    {
                                        RowPosition = row,
                                        ColPosition = col,
                                        ReachNum = 0
                                    };
                                    knightsReach.Add(currKnight);
                                }
                                knightsReach.FirstOrDefault(x => x.RowPosition == row && x.ColPosition == col).ReachNum++;
                            }

                            //Check 2xDown 1xLeft
                            if (IsLocationValid(row + 2, col - 1, boardSize) && chessBoard[row + 2, col - 1] == "K")
                            {
                                if (!knightsReach.Any(x => x.RowPosition == row && x.ColPosition == col))
                                {
                                    KnightReach currKnight = new KnightReach
                                    {
                                        RowPosition = row,
                                        ColPosition = col,
                                        ReachNum = 0
                                    };
                                    knightsReach.Add(currKnight);
                                }
                                knightsReach.FirstOrDefault(x => x.RowPosition == row && x.ColPosition == col).ReachNum++;
                            }
                        }
                    }
                }

                if (!knightsReach.Any())
                {
                    return knightRemoved;
                }

                knightsReach = knightsReach.OrderByDescending(x => x.ReachNum).ToList();

                int cellRow = knightsReach[0].RowPosition;
                int cellCol = knightsReach[0].ColPosition;
                chessBoard[cellRow, cellCol] = "0";
                knightRemoved++;
            }

            return knightRemoved;
        }

        private static bool IsLocationValid(int row, int col, int boardSize)
        {
            return row < boardSize && row >= 0 && col < boardSize && col >= 0;
        }

        private static void FillChessBoard(ref string[,] chessBoard, int boardSize)
        {
            for (int row = 0; row < boardSize; row++)
            {
                string rowInput = Console.ReadLine();

                for (int col = 0; col < boardSize; col++)
                {
                    chessBoard[row, col] = rowInput[col].ToString();
                }
            }
        }
        private class KnightReach
        {
            public int RowPosition { get; set; }

            public int ColPosition { get; set; }

            public int ReachNum { get; set; }
        }
    }
}
