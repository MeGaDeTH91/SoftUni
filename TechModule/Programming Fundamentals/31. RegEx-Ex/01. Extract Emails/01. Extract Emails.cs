using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _01.Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=\s|^)[a-z0-9]+([-.]\w*)*@[a-z]+([-.]\w*)*(\.[a-z]+)";

            string text = Console.ReadLine();
            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match item in matches)
            {
                Console.WriteLine(item);
            }
        }
    }
}
