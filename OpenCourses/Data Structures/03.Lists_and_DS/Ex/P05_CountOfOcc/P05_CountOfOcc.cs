using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_CountOfOcc
{
    class P05_CountOfOcc
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> occurencies = new Dictionary<int, int>();

            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            foreach (var num in nums)
            {
                if (!occurencies.ContainsKey(num))
                {
                    occurencies[num] = 1;
                }
                else
                {
                    occurencies[num]++;
                }
            }

            foreach (var pair in occurencies.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value} times");
            }
        }
    }
}
