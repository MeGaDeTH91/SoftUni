namespace _04.RodCut
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int length = 0;
        private static int[] prices;
        private static int[] bestPrices;
        private static int[] bestCombo;
        private static List<int> result = new List<int>();

        public static void Main()
        {
            prices = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bestPrices = new int[prices.Length];
            bestCombo = new int[prices.Length];

            length = int.Parse(Console.ReadLine());

            int bestSolution = CutRope();

            Console.WriteLine(bestSolution);
            PrintResult();
        }

        private static void PrintResult()
        {
            while (length > 0)
            {
                int next = bestCombo[length];
                result.Add(next);
                length -= next;
            }
            
            Console.WriteLine(string.Join(" ", result));
        }

        private static int CutRope()
        {
            for (int i = 1; i <= length; i++)
            {
                int currentBest = bestPrices[i];

                for (int j = 1; j <= i; j++)
                {
                    currentBest = Math.Max(currentBest, prices[j] + bestPrices[i - j]);

                    if(currentBest > bestPrices[i])
                    {
                        bestPrices[i] = currentBest;
                        bestCombo[i] = j;
                    }
                }
            }
            return bestPrices[length];
        }
    }
}
