using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Odd_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> nums = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToList();
            for (int i = 0; i < nums.Count; i++)
            {
                
                if(nums[i] % 2 > 0)
                {
                    nums.RemoveAt(i);
                    i--;
                }
            }
            
            double average = 0.0d;
            average = nums.Average();
            for (int i = 0; i < nums.Count; i++)
            {
                if(nums[i] > average)
                {
                    nums[i]++;
                }
                else if(nums[i] <= average)
                {
                    nums[i]--;
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
