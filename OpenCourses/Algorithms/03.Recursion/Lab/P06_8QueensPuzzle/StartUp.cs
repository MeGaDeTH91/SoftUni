using System;
using System.Collections.Generic;

namespace P06_8QueensPuzzle
{
    class StartUp
    {
        private const int Size = 8;
        static int[,] chessBoard = new int[Size, Size];

        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedCols = new HashSet<int>();

        static void Main(string[] args)
        {
            Solve(0);
        }

        private static void Solve(int row)
        {
            if(row == Size)
            {
                PrintChessboard();
                return;
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if(IsFreeToPutQueen(row, col))
                    {
                        MarkAllAttackedCells(row, col);
                        Solve(row + 1);
                        UnmarkAllAttackedCells(row, col);
                    }
                }
            }
        }
        
        private static void MarkAllAttackedCells(int row, int col)
        {
            PutQueen(row, col);
            MarkDirections(row, col);
        }
        private static void MarkDirections(int row, int col)
        {
            attackedRows.Add(row);
            attackedCols.Add(col);
        }
        private static bool CheckDiagonals(int row, int col)
        {
            bool rightUp = CheckRightUp(row, col);
            bool rightDown = CheckRightDown(row, col);
            bool leftUp = CheckLeftUp(row, col);
            bool leftDown = CheckLeftDown(row, col);

            return rightUp && rightUp && leftUp && leftDown;
        }
        private static bool CheckLeftDown(int row, int col)
        {
            while(row < Size && col >= 0)
            {
                if(chessBoard[row, col] == 1)
                {
                    return false;
                }
                row++;
                col--;
            }
            return true;
        }
        private static bool CheckLeftUp(int row, int col)
        {
            while (row >= 0 && col >= 0)
            {
                if (chessBoard[row, col] == 1)
                {
                    return false;
                }
                row--;
                col--;
            }
            return true;
        }
        private static bool CheckRightDown(int row, int col)
        {
            while (row < Size && col < Size)
            {
                if (chessBoard[row, col] == 1)
                {
                    return false;
                }
                row++;
                col++;
            }
            return true;
        }
        private static bool CheckRightUp(int row, int col)
        {
            while (row >= 0 && col < Size)
            {
                if (chessBoard[row, col] == 1)
                {
                    return false;
                }
                row--;
                col++;
            }
            return true;
        }

        private static void UnmarkAllAttackedCells(int row, int col)
        {
            RemoveQueen(row, col);
            UnMarkDirections(row, col);
        }
        private static void UnMarkDirections(int row, int col)
        {
            attackedRows.Remove(row);
            attackedCols.Remove(col);
        }

        private static bool IsFreeToPutQueen(int row, int col)
        {
            if (attackedRows.Contains(row) || attackedCols.Contains(col))
            {
                return false;
            }

            bool allDiagonalsAreFreeToGo = CheckDiagonals(row, col);
            bool isDiagonalFree = chessBoard[row, col] == 0;
            bool endResult = allDiagonalsAreFreeToGo && isDiagonalFree;
            return endResult;
        }
        private static void PutQueen(int row, int col)
        {
            chessBoard[row, col] = 1;
        }
        private static void RemoveQueen(int row, int col)
        {
            chessBoard[row, col] = 0;
        }
        private static void PrintChessboard()
        {

            for (int row = 0; row < Size; row++)
            {
                string[] colArr = new string[Size];
                for (int col = 0; col < Size; col++)
                {
                    char currentCell = chessBoard[row, col] == 1 ? '*' : '-';
                    Console.Write($"{currentCell} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
