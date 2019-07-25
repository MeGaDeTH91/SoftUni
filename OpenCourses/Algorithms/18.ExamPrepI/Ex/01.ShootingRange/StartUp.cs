namespace _01.ShootingRange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int targetSum = 0;
        private static int[] set;
        private static bool[] marked;

        public static void Main()
        {
            set = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            targetSum = int.Parse(Console.ReadLine());
            marked = new bool[set.Length];

            Permute(0);
        }

        private static void Permute(int index)
        {
            int sum = CalculateCurrentSum();

            if(sum == targetSum)
            {
                PrintCurrentSet();
            }
            if (index >= set.Length || sum > targetSum)
            {
                return;
            }
            else
            {
                HashSet<int> swapped = new HashSet<int>();

                for (int i = index; i < set.Length; i++)
                {
                    if (!swapped.Contains(set[i]))
                    {
                        marked[index] = true;
                        Swap(index, i);
                        Permute(index + 1);
                        Swap(index, i);
                        swapped.Add(set[i]);
                        marked[index] = false;
                    }
                }
            }
        }

        private static void PrintCurrentSet()
        {
            var tempList = new List<int>();

            for (int i = 0; i < set.Length; i++)
            {
                if (marked[i])
                {
                    tempList.Add(set[i]);
                }
            }
            Console.WriteLine(string.Join(" ", tempList));
        }

        private static int CalculateCurrentSum()
        {
            int sum = 0;
            int multiplier = 1;

            for (int j = 0; j < set.Length; j++)
            {
                if (marked[j])
                {
                    sum += set[j] * multiplier++;
                }
            }

            return sum;
        }

        private static void Swap(int index, int i)
        {
            int element = set[index];
            set[index] = set[i];
            set[i] = element;
        }
    }
}
