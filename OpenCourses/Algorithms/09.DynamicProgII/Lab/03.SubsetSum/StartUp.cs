namespace _03.SubsetSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int[] set;
        private static int sum = 0;
        private static Dictionary<int, int> sums = new Dictionary<int, int>();

        public static void Main()
        {
            ReadInput();

            FindAllPossibleSums();

            PrintResult();
        }

        private static void PrintResult()
        {
            if (sums.ContainsKey(sum))
            {
                Console.WriteLine("Yes!");
                List<int> result = new List<int>();
                
                while (sum != 0)
                {
                    int lastNum = sums[sum];
                    result.Add(lastNum);
                    sum -= lastNum;
                }

                result.Reverse();

                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("No!");
            }
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

            sum = int.Parse(Console.ReadLine());
        }
    }
}
