using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Sum_Reversed_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            string[] revArray = new string[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                int currentNum = nums[i];
                string currentNumToStr = currentNum.ToString();
                var reversedCharArr = currentNumToStr.Reverse().ToArray();
                var reversedString = new string(reversedCharArr);
                nums[i] = int.Parse(reversedString);
            }
            Console.WriteLine(String.Join(" ", nums.Sum()));
        }
    }
}
