namespace _01.BinomCoefficients
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static long[][] coefficients;
        private static long rowNum = 0;
        private static long colNum = 0;

        public static void Main()
        {
            ReadInputInitialize();

            long number = FindCoefficients(rowNum, colNum);

            Console.WriteLine(number);
        }

        private static long FindCoefficients(long row, long col)
        {
            if(col > row)
            {
                return 0;
            }

            if(row == col || col == 0)
            {
                return 1;
            }

            if (coefficients[row][col] != 0)
            {
                return coefficients[row][col];
            }
            long coefficient = FindCoefficients(row - 1, col - 1) + FindCoefficients(row - 1, col);

            coefficients[row][col] = coefficient;

            return coefficient;
        }

        private static void ReadInputInitialize()
        {
            rowNum = int.Parse(Console.ReadLine());
            colNum = int.Parse(Console.ReadLine());

            coefficients = new long[rowNum + 1][];

            for (int row = 0; row <= rowNum; row++)
            {
                coefficients[row] = new long[row + 2];
            }
        }
    }
}
