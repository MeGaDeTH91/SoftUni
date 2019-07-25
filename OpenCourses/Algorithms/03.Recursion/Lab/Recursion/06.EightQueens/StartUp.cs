namespace _06.EightQueens
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private const int boardSize = 8;
        private static bool[,] chessboard = new bool[boardSize, boardSize];
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        public static void Main()
        {
            PutQueens(0);
        }
        
        private static void PutQueens(int row)
        {
            if(row == boardSize)
            {
                PrintBoard();
            }
            else
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if(SafeToPutQueen(row, col))
                    {
                        MarkAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAttackedPositions(row, col);
                    }
                }
            }
        }
        
        private static void MarkAttackedPositions(int row, int col)
        {
            chessboard[row, col] = true;
            attackedRows.Add(row);
            attackedCols.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(col + row);
        }
        private static void UnmarkAttackedPositions(int row, int col)
        {
            chessboard[row, col] = false;
            attackedRows.Remove(row);
            attackedCols.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(col + row);
        }
        
        private static bool SafeToPutQueen(int row, int col)
        {
            bool itIsSafe = 
                attackedLeftDiagonals.Contains(col - row) ||
                attackedRightDiagonals.Contains(col + row) || 
                attackedRows.Contains(row)                || 
                attackedCols.Contains(col);

            return !itIsSafe;
        }

        private static void PrintBoard()
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    char currentCell = chessboard[row, col] ? '*' : '-';
                    Console.Write($"{currentCell} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
