using System;
using System.Linq;

namespace _1._Matrix_of_Palindromes
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

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string[,] matrix = new string[rowsCount, colsCount];

            for (int rows = 0; rows < rowsCount; rows++)
            {
                for (int cols = 0; cols < colsCount; cols++)
                {
                    int max = Math.Max(cols, rows);
                    string current = $"{alphabet[rows]}{alphabet[cols + rows]}{alphabet[rows]}";

                    matrix[rows, cols] = current;
                }
            }

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write($"{matrix[rows, cols]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
