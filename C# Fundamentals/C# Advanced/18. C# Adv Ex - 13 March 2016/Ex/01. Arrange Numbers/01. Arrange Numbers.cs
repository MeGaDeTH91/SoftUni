using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Arrange_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numsInText = new List<string>() { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }.ToList();

            List<Pair> resultDic = new List<Pair>();

            List<string> numbers = Console.ReadLine()
                                .Split(new[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                                .ToList();

            foreach (var num in numbers)
            {
                string currKey = num;
                string currValue = string.Empty;
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < num.Length; i++)
                {
                    sb.Append(MakeMeProperString(num[i], numsInText));
                }
                currValue = sb.ToString();

                Pair currPair = new Pair
                {
                    Number = currKey,
                    NumberInText = currValue
                };
                resultDic.Add(currPair);
            }
            PrintResult(resultDic);
        }

        private static void PrintResult(List<Pair> resultDic)
        {
            int count = 0;
            int lastElement = resultDic.Count;
            foreach (var num in resultDic.OrderBy(x => x.NumberInText))
            {
                count++;
                if (count == lastElement)
                {
                    Console.Write($"{num.Number} ");
                }
                else
                {
                    Console.Write($"{num.Number}, ");
                }
            }
            Console.WriteLine();
        }

        private static string MakeMeProperString(char currentLetter, List<string> textNum)
        {
            int currLetterNum = int.Parse(currentLetter.ToString());
            return textNum[currLetterNum];
        }
        public class Pair
        {
            public string Number { get; set; }
            public string NumberInText { get; set; }
        }
    }
}
