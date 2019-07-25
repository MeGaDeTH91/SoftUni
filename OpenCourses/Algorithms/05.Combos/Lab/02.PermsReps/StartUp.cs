namespace _02.PermsReps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static string[] set;

        public static void Main()
        {
            set = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= set.Length)
            {
                Console.WriteLine(string.Join(" ", set));
            }
            else
            {
                HashSet<string> swapped = new HashSet<string>();

                for (int i = index; i < set.Length; i++)
                {
                    if (!swapped.Contains(set[i]))
                    {
                        Swap(index, i);
                        Permute(index + 1);
                        Swap(index, i);
                        swapped.Add(set[i]);
                    }
                }
            }
        }

        private static void Swap(int index, int i)
        {
            string element = set[index];
            set[index] = set[i];
            set[i] = element;
        }
    }
}
