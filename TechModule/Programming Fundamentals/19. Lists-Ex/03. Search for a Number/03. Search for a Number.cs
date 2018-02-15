using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Search_for_a_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            int[] details = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int rangeForChange = details[0];
            int deleteElements = details[1];
            int searchedNumber = details[2];
            bool isFound = false;
            for (int i = 1; i <= deleteElements; i++)
            {
                nums.RemoveAt(0);
            }
            for (int i = 0; i < rangeForChange - deleteElements; i++)
            {
                if(nums[i] == searchedNumber)
                {
                    isFound = true;
                }
            }
            if(isFound)
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
