using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_LongestSub
{
    class P03_LongestSub
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            numbers.Add(0);
            int longestCount = 0;
            int currentCount = 0;

            List<int> resultList = new List<int>();

            List<int> temp = new List<int>();

            if(numbers.Count == 2)
            {
                Console.WriteLine(numbers[0]);
                return;
            }

            for (int index = 0; index < numbers.Count - 1; index++)
            {
                if (numbers[index] == numbers[index + 1])
                {
                    currentCount++;
                    temp.Add(numbers[index]);
                }
                else if(currentCount > 0)
                {
                    temp.Add(numbers[index]);
                    currentCount++;

                    if(longestCount < currentCount)
                    {
                        longestCount = currentCount;
                        resultList = new List<int>(temp);
                    }
                    currentCount = 0;
                    temp = new List<int>();
                }
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
