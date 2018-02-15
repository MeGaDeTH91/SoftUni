using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _05.Match_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";
            string text = Console.ReadLine();

            MatchCollection regex = Regex.Matches(text, pattern);

            foreach (var item in regex)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
