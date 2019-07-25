namespace _03.DividingPresents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int[] set;
        //private static int sum = 0;
        private static Dictionary<int, int> sums = new Dictionary<int, int>();

        public static void Main()
        {
            ReadInput();

            FindAllPossibleSums();

            PrintResult();
        }

        private static void PrintResult()
        {
            int half = (int)Math.Floor((double)set.Sum() / 2);
            var orderedSums = sums.Keys.OrderBy(x => x).ToList();

            if (!sums.ContainsKey(half))
            {
                for (int sum = half; sum >= 0; sum--)
                {
                    int currentSum = orderedSums[sum];
                    if (sums.ContainsKey(sum))
                    {
                        half = sum;
                        break;
                    }
                }
            }
            
            int otherHalf = set.Sum() - half;

            int difference = otherHalf - half;
            
            List<int> result = new List<int>();

            int tempSum = half;

            while (tempSum != 0)
            {
                int lastNum = sums[tempSum];
                result.Add(lastNum);
                tempSum -= lastNum;
            }

            Console.WriteLine($"Difference: {difference}");
            Console.WriteLine($"Alan:{half} Bob:{otherHalf}");
            Console.WriteLine($"Alan takes: {string.Join(" ", result)}");
            Console.WriteLine("Bob takes the rest.");
        }

        private static void FindAllPossibleSums()
        {
            sums.Add(0, 0);

            foreach (var num in set)
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
            set = Console.ReadLine()
                            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
        }
    }
}
