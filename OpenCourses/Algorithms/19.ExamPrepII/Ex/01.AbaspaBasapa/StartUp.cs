namespace _01.AbaspaBasapa
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static int[][] lcs;
        private static char[] firstWord;
        private static char[] secondWord;
        private static int maxRowIndex = 0;
        private static int maxColIndex = 0;
        private static int max = 0;

        public static void Main()
        {
            ReadInputInitialize();

            CountLCS();

            PrintResult();
        }

        private static void PrintResult()
        {
            int row = maxRowIndex;
            int col = maxColIndex;

            List<char> resultArr = new List<char>();

            while (row > 0 && col > 0 && max != 0)
            {
                resultArr.Add(firstWord[row - 1]);
                row--;
                col--;
                max--;
            }

            resultArr.Reverse();

            Console.WriteLine(string.Join("", resultArr));
        }

        private static void CountLCS()
        {
            for (int row = 1; row < lcs.Length; row++)
            {
                for (int col = 1; col < lcs[row].Length; col++)
                {
                    char leftLetter = firstWord[row - 1];
                    char rightLetter = secondWord[col - 1];

                    int leftTopElement = lcs[row - 1][col - 1];

                    if (leftLetter == rightLetter)
                    {
                        lcs[row][col] = leftTopElement + 1;
                    }
                    else
                    {
                        lcs[row][col] = 0;
                    }
                    if(lcs[row][col] > max)
                    {
                        max = lcs[row][col];
                        maxRowIndex = row;
                        maxColIndex = col;
                    }
                }
            }
        }

        private static void ReadInputInitialize()
        {
            firstWord = Console.ReadLine().ToCharArray();
            secondWord = Console.ReadLine().ToCharArray();

            lcs = new int[firstWord.Length + 1][];

            for (int row = 0; row < lcs.Length; row++)
            {
                lcs[row] = new int[secondWord.Length + 1];
            }
        }
    }
}
