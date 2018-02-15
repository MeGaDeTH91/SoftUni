using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SumBigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                 .Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();
            decimal result = 0m;
            foreach (var item in input)
            {
                char firstLetter = item.First();
                char lastLetter = item.Last();
                var currNum = decimal.Parse(item.Substring(1, item.Length - 2));

                if(char.IsUpper(firstLetter))
                {
                    currNum /= firstLetter - ('A' - 1);
                }
                else
                {
                    currNum *= firstLetter - ('a' - 1);
                }
                if (char.IsUpper(lastLetter))
                {
                    currNum -= lastLetter - ('A' - 1);
                }
                else
                {
                    currNum += lastLetter - ('a' - 1);
                }
                result += currNum;
            }
            Console.WriteLine($"{result:F2}");
        }
    }
}