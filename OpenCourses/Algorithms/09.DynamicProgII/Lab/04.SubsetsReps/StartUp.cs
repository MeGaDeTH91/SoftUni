namespace _04.SubsetsReps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] set = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int targetSum = int.Parse(Console.ReadLine());

            bool[] possibleSums = FindPossibleSums(set, targetSum);

            var subset = FindSubset(set, targetSum, possibleSums);

            Console.WriteLine(subset.Count());
        }

        private static IEnumerable<int> FindSubset(int[] set, int targetSum, bool[] possibleSums)
        {
            var subset = new List<int>();

            while (targetSum > 0)
            {
                for (int i = 0; i < set.Length; i++)
                {
                    int newSum = targetSum - set[i];
                    if(newSum >= 0 && possibleSums[newSum])
                    {
                        targetSum = newSum;
                        subset.Add(set[i]);
                    }
                }
            }

            return subset;
        }

        private static bool[] FindPossibleSums(int[] set, int targetSum)
        {
            bool[] possible = new bool[targetSum + 1];
            possible[0] = true;

            for (int sum = 0; sum < possible.Length; sum++)
            {
                if (possible[sum])
                {
                    for (int i = 0; i < set.Length; i++)
                    {
                        int newSum = sum + set[i];
                        if(newSum <= targetSum)
                        {
                            possible[newSum] = true;
                        }
                    }
                }
            }

            return possible;
        }
    }
}
