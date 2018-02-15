using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03.Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string txtPattern = @"[0-9]+";
            string numPattern = @"[\D]+";
            string text = Console.ReadLine();
            string[] letterGroups = Regex.Split(text, txtPattern)
                .Where(x => x != string.Empty)
                .ToArray();
            int[] nums = Regex.Split(text, numPattern)
                .Where(x => x!= string.Empty)
                .Select(int.Parse)
                .ToArray();
            StringBuilder resultStr = new StringBuilder();
            List<char> uniques = new List<char>();

            for (int i = 0; i < letterGroups.Length; i++)
            {
                string currGroup = letterGroups[i];
                int currNum = nums[i];
                string upperStr = currGroup.ToUpper();
                foreach (char ch in upperStr)
                {
                    uniques.Add(ch);
                }
                for (int j = 0; j < currNum; j++)
                {
                    resultStr.Append(upperStr);
                }
            }
            string distincted = new string(resultStr.ToString().Distinct().ToArray());
            Console.WriteLine($"Unique symbols used: {distincted.Length}");
            Console.WriteLine(resultStr);
        }
    }
}
