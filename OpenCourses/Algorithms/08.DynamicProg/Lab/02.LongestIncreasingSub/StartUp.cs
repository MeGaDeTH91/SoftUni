namespace _02.LongestIncreasingSub
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private static int[] set;
        private static int[] indexes;
        private static int[] prev;
        private static List<int> result = new List<int>();
        private static int maxLen = -1;

        public static void Main()
        {
            set = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            indexes = new int[set.Length];
            prev = new int[set.Length];

            FindLongestSequence();
            
            Console.WriteLine(string.Join(" ", result));
        }

        private static void FindLongestSequence()
        {
            int bestSolution = 0;
            int lastIndex = -1;

            for (int currIndex = 0; currIndex < set.Length; currIndex++)
            {
                int currentElement = set[currIndex];

                indexes[currIndex] = 1;
                prev[currIndex] = -1;

                for (int solIndex = 0; solIndex < currIndex; solIndex++)
                {
                    int checkElement = set[solIndex];

                    if(checkElement < currentElement && indexes[solIndex] >= indexes[currIndex])
                    {
                        indexes[currIndex] = indexes[solIndex] + 1;
                        prev[currIndex] = solIndex;
                    }
                }
                if(indexes[currIndex] > bestSolution)
                {
                    bestSolution = indexes[currIndex];
                    lastIndex = currIndex;
                }
            }

            while(lastIndex != -1)
            {
                result.Add(set[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            result.Reverse();
        }
    }
}
