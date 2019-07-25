namespace _01.Blocks
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static char[] set;
        private static char[] vector;
        private static bool[] used;
        private static HashSet<string> allPossibleCombos;
        private static List<string> result;

        public static void Main()
        {
            ReadInput();

            CheckBlocks(0);

            PrintResult();
        }

        private static void CheckBlocks(int index)
        {
            if (index >= vector.Length)
            {
                string current = new string(vector);

                if (!allPossibleCombos.Contains(current))
                {
                    result.Add(current);

                    allPossibleCombos.Add(current);
                    allPossibleCombos.Add(new string(new[] { vector[3], vector[0], vector[2], vector[1] }));
                    allPossibleCombos.Add(new string(new[] { vector[2], vector[3], vector[1], vector[0] }));
                    allPossibleCombos.Add(new string(new[] { vector[1], vector[2], vector[0], vector[3] }));
                }
            }
            else
            {
                for (int i = 0; i < set.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        vector[index] = set[i];
                        CheckBlocks(index + 1);
                        used[i] = false;
                    }

                }
            }
        }
        
        private static void PrintResult()
        {
            Console.WriteLine($"Number of blocks: {result.Count}");

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static void ReadInput()
        {
            int n = int.Parse(Console.ReadLine());

            set = new char[n];
            vector = new char[4];
            used = new bool[n];

            allPossibleCombos = new HashSet<string>();
            result = new List<string>();

            for (int i = 0; i < n; i++)
            {
                set[i] = (char)(i + 65);
            }
        }
    }
}
