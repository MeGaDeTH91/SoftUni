using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            string snake = Console.ReadLine();

            int rowCount = matrixSizes[0];
            int colCount = matrixSizes[1];

            string[,] matrix = new string[rowCount, colCount];

            FillMatrix(matrix, snake, rowCount, colCount);
            
            int[] shotParams = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            int impactRow = shotParams[0];
            int impactCol = shotParams[1];
            int radius = shotParams[2];            

            FireAShot(matrix, impactRow, impactCol, radius, rowCount, colCount);

            DropCharacters(matrix, rowCount, colCount);

            PrintMatrix(matrix, rowCount, colCount);
        }

        private static void DropCharacters(string[,] matrix, int rowCount, int colCount)
        {
            for (int rows = rowCount - 1; rows > 0; rows--)
            {
                int rowMarker = rowCount - 1;

                while (rowMarker > 0)
                {
                    if (matrix[rowMarker, rows] == " ")
                    {
                        if (matrix[rowMarker - 1, rows] != " ")
                        {
                            matrix[rowMarker, rows] = matrix[rowMarker - 1, rows];
                            matrix[rowMarker - 1, rows] = " ";
                            rowMarker++;
                        }
                        else
                        {
                            for (int index = rowMarker; index >= 0; index--)
                            {
                                if (matrix[index, rows] != " ")
                                {
                                    matrix[rowMarker, rows] = matrix[index, rows];
                                    matrix[index, rows] = " ";
                                }
                            }
                        }
                    }
                    rowMarker--;
                }
            }
        }

        private static void PrintMatrix(string[,] matrix, int rowCount, int colCount)
        {
            for (int rows = 0; rows < rowCount; rows++)
            {

                for (int cols = 0; cols < colCount; cols++)
                {
                    Console.Write($"{matrix[rows, cols]}");
                }
                Console.WriteLine();
            }
        }

        private static void FireAShot(string[,] matrix, int impactRow, int impactCol, int radius, int rowCount, int colCount)
        {
            int rowUpDiff = impactRow - radius;
            int rowDownDiff = impactRow + radius;

            int colRightDiff = impactCol + radius;
            int colLeftDiff = impactCol - radius;

            int rightStep = Math.Min(colRightDiff + 1, colCount);
            int downStep = Math.Min(rowDownDiff + 1, rowCount);
            int leftStep = Math.Max(colLeftDiff, 0);
            int upStep = Math.Max(rowUpDiff, 0);

            int counter = 0;
            for (int right = impactCol; right < rightStep; right++)
            {
                matrix[impactRow, right] = " ";
                if (counter == 1)
                {
                    if (impactRow + 1 < rowCount)
                    {
                        matrix[impactRow + 1, right] = " ";
                    }
                    if (impactRow - 1 >= 0)
                    {
                        matrix[impactRow - 1, right] = " ";
                    }
                }
                counter++;
            }
            for (int down = impactRow; down < downStep; down++)
            {
                matrix[down, impactCol] = " ";
            }
            counter = 0;
            for (int left = impactCol; left >= leftStep; left--)
            {
                matrix[impactRow, left] = " ";
                if (counter == 1)
                {
                    if (impactRow + 1 < rowCount)
                    {
                        matrix[impactRow + 1, left] = " ";
                    }
                    if (impactRow - 1 >= 0)
                    {
                        matrix[impactRow - 1, left] = " ";
                    }
                }
                counter++;
            }
            for (int up = impactRow; up >= upStep; up--)
            {
                matrix[up, impactCol] = " ";
            }
        }

        private static void FillMatrix(string[,] matrix, string snakeInput, int rowCount, int colCount)
        {
            Queue<string> snake = new Queue<string>();

            for (int i = 0; i < snakeInput.Length; i++)
            {
                snake.Enqueue(snakeInput[i].ToString());
            }

            int rowCounter = 1;
            for (int rows = rowCount - 1; rows >= 0; rows--)
            {
                int currCols = 0;
                if (rowCounter % 2 != 0)
                {
                    currCols = colCount - 1;
                }
                else
                {
                    currCols = 0;
                }

                while (currCols >= 0 && currCols < colCount)
                {
                    string currLetter = snake.Dequeue();

                    matrix[rows, currCols] = currLetter;

                    snake.Enqueue(currLetter);
                    if (rowCounter % 2 != 0)
                    {
                        currCols--;
                    }
                    else
                    {
                        currCols++;
                    }
                }
                rowCounter++;
            }
        }
    }
}
