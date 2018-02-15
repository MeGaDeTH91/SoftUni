using System;
using System.Linq;

namespace _3._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                          .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();

            int rowsCount = input[0];
            int colsCount = input[1];

            int equalCells = 0;

            string[,] matrix = new string[rowsCount, colsCount];

            for (int rows = 0; rows < rowsCount; rows++)
            {
                string[] inputLine = Console.ReadLine()
                                   .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();
                for (int cols = 0; cols < colsCount; cols++)
                {
                    matrix[rows, cols] = inputLine[cols]; 
                }
            }

            for (int rows = 0; rows < rowsCount - 1; rows++)
            {
                for (int cols = 0; cols < colsCount - 1; cols++)
                {
                    string firstChar = matrix[rows, cols];
                    string secondChar = matrix[rows , cols + 1];
                    string thirdChar = matrix[rows + 1, cols];
                    string fourthChar = matrix[rows + 1, cols + 1];

                    if(firstChar == secondChar && secondChar == thirdChar && 
                        thirdChar == fourthChar)
                    {
                        equalCells++;
                    }
                }
            }

            Console.WriteLine(equalCells);
        }
    }
}
