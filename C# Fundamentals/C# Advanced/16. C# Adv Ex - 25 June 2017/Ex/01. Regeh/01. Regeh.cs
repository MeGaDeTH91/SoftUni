using System;
using System.Text.RegularExpressions;

namespace _01._Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\[([^ \f\v\t\r\n\[]+)<(?<nums1>[0-9]+)REGEH(?<nums2>[0-9]+)>([^ \f\v\t\r\n\]]+)\]";

            Regex rgx = new Regex(pattern);

            int sumOfIndexes = 0;

            int currIndex = 0;
            string result = string.Empty;

            string input = Console.ReadLine();

            MatchCollection matches = rgx.Matches(input);

            foreach (Match m in matches)
            {
                int leftNum = int.Parse(m.Groups["nums1"].Value);
                int rightNum = int.Parse(m.Groups["nums2"].Value);

                currIndex = sumOfIndexes + leftNum;
                if (currIndex >= input.Length)
                {
                    currIndex = currIndex - input.Length;
                }
                result += input[currIndex];
                sumOfIndexes += leftNum;

                currIndex = sumOfIndexes + rightNum;
                if (currIndex >= input.Length)
                {
                    currIndex = currIndex - input.Length;
                }
                result += input[currIndex];
                sumOfIndexes += rightNum;
            }
                
            

            Console.WriteLine(result);
        }
    }
}
