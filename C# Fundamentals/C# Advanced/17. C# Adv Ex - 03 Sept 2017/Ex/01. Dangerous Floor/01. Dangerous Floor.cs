namespace _01._Dangerous_Floor
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string[,] chessBoard = new string[8, 8];
            FillChessBoard(ref chessBoard);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string currFigure = command[0].ToString();
                int startRow = int.Parse(command.Substring(1, 1));
                int startCol = int.Parse(command.Substring(2, 1));
                int destinationRow = int.Parse(command.Substring(4, 1));
                int destinationCol = int.Parse(command.Substring(5, 1));
                
                if(!IsPieceValid(chessBoard, startRow, startCol, currFigure))
                {
                    Console.WriteLine($"There is no such a piece!");
                }
                else if(!IsMoveValid(chessBoard, startRow, startCol, destinationRow, destinationCol, currFigure))
                {
                    Console.WriteLine("Invalid move!");
                }
                else if(!IsCellValid(chessBoard, destinationRow, destinationCol))
                {
                    Console.WriteLine($"Move go out of board!");
                }
                else
                {
                    chessBoard[destinationRow, destinationCol] = currFigure;
                    chessBoard[startRow, startCol] = "x";
                }
            }
        }
        private static bool IsPieceValid(string[,] chessBoard, int checkRow, int checkCol, string figureType)
        {
            if(chessBoard[checkRow, checkCol] == figureType)
            {
                return true;
            }
            return false;
        }
        private static bool IsMoveValid(string[,] chessBoard, int startRow, int startCol, int destinationRow, int destinationCol, string figureType)
        {
            if(figureType == "K")
            {
                return Math.Abs(startRow - destinationRow) <= 1 && Math.Abs(startCol - destinationCol) <= 1;
            }
            else if (figureType == "R")
            {
                return IsValidRookMove(startRow, startCol, destinationRow, destinationCol);
            }
            else if (figureType == "B")
            {
                return IsValidBishopMove(startRow, startCol, destinationRow, destinationCol);
            }
            else if (figureType == "Q")
            {
                return IsValidRookMove(startRow, startCol, destinationRow, destinationCol) || IsValidBishopMove(startRow, startCol, destinationRow, destinationCol);
            }
            else if (figureType == "P")
            {
                return startRow - destinationRow <= 2 && startRow - destinationRow > 0 && startCol == destinationCol;
            }
            return true;
        }
        private static bool IsValidBishopMove(int startRow, int startCol, int destinationRow, int destinationCol)
        {
            bool rightUp = Math.Abs(startRow - destinationRow) - Math.Abs(startCol + destinationCol) == 0;
            bool rightDown = Math.Abs(startRow + destinationRow) - Math.Abs(startCol + destinationCol) == 0;
            bool leftUp = Math.Abs(startRow - destinationRow) - Math.Abs(startCol - destinationCol) == 0;
            bool leftDown = Math.Abs(startRow + destinationRow) - Math.Abs(startCol - destinationCol) == 0;

            if(rightUp || rightDown || leftUp || leftDown)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool IsValidRookMove(int startRow, int startCol, int destinationRow, int destinationCol)
        {
            return startRow == destinationRow || startCol == destinationCol;
        }
        private static bool IsCellValid(string[,] chessBoard, int row, int col)
        {
            return row < 8 && row >= 0 && col < 8 && col >= 0;
        }
        private static void FillChessBoard(ref string[,] chessBoard)
        {
            for (int row = 0; row < 8; row++)
            {
                string[] currRowInput = Console.ReadLine()
                                        .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();
                for (int col = 0; col < 8; col++)
                {
                    chessBoard[row, col] = currRowInput[col];
                }
            }
        }
    }
}
