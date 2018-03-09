using System;
using System.Linq;

namespace P01_SumNAVG
{
    class P01_SumNAVG
    {
        static void Main(string[] args)
        {
            int[] inputNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sum = inputNums.Sum();
            double avg = inputNums.Average();

            Console.WriteLine($"Sum={sum}; Average={avg:F2}");
        }
    }
}
