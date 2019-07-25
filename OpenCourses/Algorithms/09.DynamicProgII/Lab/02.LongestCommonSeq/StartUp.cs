namespace _02.LongestCommonSeq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int[][] lcs;
        private static char[] firstWord;
        private static char[] secondWord;

        public static void Main()
        {
            ReadInputInitialize();

            CountLCS();

            PrintResult();
        }
        
        private static void PrintResult()
        {
            int row = lcs.Length - 1;
            int col = lcs[0].Length - 1;

            List<char> resultArr = new List<char>();

            while (row > 0 && col > 0)
            {
                if(firstWord[row - 1] == secondWord[col - 1])
                {
                    resultArr.Add(firstWord[row - 1]);
                    row--;
                    col--;
                }
                else if(lcs[row][col - 1] > lcs[row - 1][col])
                {
                    col--;
                }
                else
                {
                    row--;
                }
            }

            resultArr.Reverse();

            Console.WriteLine(string.Join("", resultArr));

            //int max = 0;

            //for (int row = 0; row < lcs.Length; row++)
            //{
            //    int currentMax = lcs[row].Max();
            //    if(currentMax > max)
            //    {
            //        max = currentMax;
            //    }
            //}

            //Console.WriteLine(max);
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
                    int topElement = lcs[row - 1][col];
                    int leftElement = lcs[row][col - 1];

                    if (leftLetter == rightLetter)
                    {
                        lcs[row][col] = leftTopElement + 1;
                    }
                    else if(topElement > leftElement)
                    {
                        lcs[row][col] = topElement;
                    }
                    else
                    {
                        lcs[row][col] = leftElement;
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
