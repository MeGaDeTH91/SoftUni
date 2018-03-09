using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_RemoveOdds
{
    class P04_RemoveOdds
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numFreq = new Dictionary<int, int>();

            List<int> numbers = Console.ReadLine().Split(new[] { ' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            foreach (var num in numbers)
            {
                if (!numFreq.ContainsKey(num))
                {
                    numFreq[num] = 1;
                }
                else
                {
                    numFreq[num]++;
                }
            }
            numFreq = numFreq.Where(x => x.Value % 2 == 0).ToDictionary(x => x.Key, y => y.Value);
            List<int> result = new List<int>();

            foreach (var numToAdd in numbers)
            {
                if(numFreq.ContainsKey(numToAdd))
                {
                    result.Add(numToAdd);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
