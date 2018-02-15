namespace _02._Knight_Game
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());

            string[,] chessBoard = new string[boardSize, boardSize];

            FillChessBoard(ref chessBoard, boardSize);

            int mostAttackedRow = 0;
            int mostAttackedCol = 0;
            int minRemoved = 0;
            int mostAttackedCell = 0;

            bool IsBoardClear = false;

            while (!IsBoardClear)
            {
                int currAttackOnCell = 0;
                for (int row = 0; row < boardSize; row++)
                {
                    for (int col = 0; col < boardSize; col++)
                    {
                        if (chessBoard[row, col] == "K")
                        {
                            currAttackOnCell = CheckBoard(ref chessBoard, boardSize, row, col);

                            if(currAttackOnCell > mostAttackedCell)
                            {
                                mostAttackedCell = currAttackOnCell;
                                mostAttackedRow = row;
                                mostAttackedCol = col;
                            }
                        }
                    }
                }
                if(mostAttackedCell == 0)
                {
                    IsBoardClear = true;
                    break;
                }
                chessBoard[mostAttackedRow, mostAttackedCol] = "0";
                mostAttackedCell = 0;
                minRemoved++;
            }
            Console.WriteLine(minRemoved);
        }

        private static int CheckBoard(ref string[,] chessBoard, int boardSize, int row, int col)
        {
            int currAttacks = 0;
            //Check 2xRight 1xUp
            if (IsLocationValid(row - 1, col + 2, boardSize))
            {
                if (chessBoard[row - 1, col + 2] == "K")
                {
                    currAttacks++;
                }
            }

            //Check 2xRight 1xDown
            if (IsLocationValid(row + 1, col + 2, boardSize))
            {
                if (chessBoard[row + 1, col + 2] == "K")
                {
                    currAttacks++;
                }
            }

            //Check 2xLeft 1xUp
            if (IsLocationValid(row - 1, col - 2, boardSize))
            {
                if (chessBoard[row - 1, col - 2] == "K")
                {
                    currAttacks++;
                }
            }

            //Check 2xLeft 1xDown
            if (IsLocationValid(row + 1, col - 2, boardSize))
            {
                if (chessBoard[row + 1, col - 2] == "K")
                {
                    currAttacks++;
                }
            }

            //Check 2xUp 1xRight
            if (IsLocationValid(row - 2, col + 1, boardSize))
            {
                if (chessBoard[row - 2, col + 1] == "K")
                {
                    currAttacks++;
                }
            }

            //Check 2xUp 1xLeft
            if (IsLocationValid(row - 2, col - 1, boardSize))
            {
                if (chessBoard[row - 2, col - 1] == "K")
                {
                    currAttacks++;
                }
            }

            //Check 2xDown 1xRight
            if (IsLocationValid(row + 2, col + 1, boardSize))
            {
                if (chessBoard[row + 2, col + 1] == "K")
                {
                    currAttacks++;
                }
            }

            //Check 2xDown 1xLeft
            if (IsLocationValid(row + 2, col - 1, boardSize))
            {
                if (chessBoard[row + 2, col - 1] == "K")
                {
                    currAttacks++;
                }
            }
            return currAttacks;
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
    }
}
