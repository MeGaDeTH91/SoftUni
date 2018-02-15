using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> borderNums = Console.ReadLine()
                             .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToList();

            int lower = borderNums[0];
            int upper = borderNums[1];

            Predicate<int> evens = number => number % 2 == 0;
            Predicate<int> odds = number => number % 2 != 0;
            
            string oddOrEven = Console.ReadLine();

            Predicate<int> resultPred = oddOrEven == "odd" ? odds : evens;

            List<int> resultList = new List<int>();

            for (int index = lower; index <= upper; index++)
            {
                if (resultPred(index))
                {
                    resultList.Add(index);
                }
            }
            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
