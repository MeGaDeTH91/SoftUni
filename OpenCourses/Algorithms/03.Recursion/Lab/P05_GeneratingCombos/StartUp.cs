using System;
using System.Linq;

namespace P05_GeneratingCombos
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] set = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int comboCount = int.Parse(Console.ReadLine());

            GenerateCombinations(set, new int[comboCount], 0, 0);
        }

        private static void GenerateCombinations(int[] set, int[] vector, int index, int border)
        {
            if(index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GenerateCombinations(set, vector, index + 1, i + 1);
                }
            }
        }
    }
}
