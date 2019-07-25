namespace _01.Elections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int[] parties;
        private static int sum = 0;
        private static Dictionary<int, int> sums = new Dictionary<int, int>();
        private static int targetMin;

        public static void Main()
        {
            ReadInput();

            FindAllPossibleSums();

            PrintResult();
        }

        private static void PrintResult()
        {
            int count = sums.Count(x => x.Key >= targetMin);

            Console.WriteLine(count);
        }

        private static void FindAllPossibleSums()
        {
            sums.Add(0, 0);

            foreach (var num in parties)
            {
                foreach (var sumNum in sums.Keys.ToList())
                {
                    int currentSum = sumNum + num;

                    if (!sums.ContainsKey(currentSum))
                    {
                        sums[currentSum] = num;
                    }
                }
            }
        }

        private static void ReadInput()
        {
            targetMin = int.Parse(Console.ReadLine());
            int partiesNum = int.Parse(Console.ReadLine());

            parties = new int[partiesNum];

            sum = 0;
            
            for (int i = 0; i < partiesNum; i++)
            {
                parties[i] = int.Parse(Console.ReadLine());
            }
        }
    }
}
