namespace _02.LongestZigZag
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int[] set;
        private static int[,] len;
        private static int[,] prev;
        private static int maxLen = 0;
        private static int maxIndexRow = 0;
        private static int maxIndexCol = 0;

        public static void Main()
        {
            ReadInput();

            FindLogestZigZag();

            PrintResult();
        }

        private static void PrintResult()
        {
            var result = new List<int>();
            
            while (maxIndexRow >= 0)
            {
                result.Add(set[maxIndexRow]);

                maxIndexRow = prev[maxIndexRow, maxIndexCol];

                if(maxIndexCol == 1)
                {
                    maxIndexCol = 0;
                }
                else
                {
                    maxIndexCol = 1;
                }
            }

            result.Reverse();

            Console.WriteLine(string.Join(" ", result));
        }

        private static void FindLogestZigZag()
        {
            for (int currentIndex = 1; currentIndex < set.Length; currentIndex++)
            {
                int currentNumber = set[currentIndex];
                
                for (int prevIndex = 0; prevIndex < currentIndex; prevIndex++)
                {
                    int prevNumber = set[prevIndex];

                    if(currentNumber > prevNumber && len[currentIndex, 0] < len[prevIndex, 1] + 1)
                    {
                        len[currentIndex, 0] = len[prevIndex, 1] + 1;
                        prev[currentIndex, 0] = prevIndex;
                    }
                    else if(currentNumber < prevNumber && len[currentIndex, 1] < len[prevIndex, 0] + 1)
                    {
                        len[currentIndex, 1] = len[prevIndex, 0] + 1;
                        prev[currentIndex, 1] = prevIndex;
                    }

                    if(len[currentIndex, 0] > maxLen)
                    {
                        maxLen = len[currentIndex, 0];
                        maxIndexRow = currentIndex;
                        maxIndexCol = 0;
                    }

                    if(len[currentIndex, 1] > maxLen)
                    {
                        maxLen = len[currentIndex, 1];
                        maxIndexRow = currentIndex;
                        maxIndexCol = 1;
                    }
                }
            }
        }

        private static void ReadInput()
        {
            set = Console.ReadLine()
                            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            len = new int[set.Length, 2];

            prev = new int[set.Length, 2];

            len[0, 0] = len[0, 1] = 1;

            prev[0, 0] = prev[0, 1] = -1;
        }
    }
}
