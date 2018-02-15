using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();
            var numCount = new SortedDictionary<double, int>();
            foreach (var item in nums)
            {
                if(numCount.ContainsKey(item))
                {
                    numCount[item]++;
                }
                else
                {
                    numCount[item] = 1;
                }
            }
            foreach (var result in numCount)
            {
                Console.WriteLine("{0} -> {1}", result.Key, result.Value);
            }
            
        }
    }
}
