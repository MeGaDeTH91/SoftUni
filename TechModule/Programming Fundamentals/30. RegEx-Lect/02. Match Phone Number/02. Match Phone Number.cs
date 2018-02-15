using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _02.Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern1 = @"[+359]{4}([- ])[2]{1}\1\d{3}\1\d{4}\b";
           
            string text = Console.ReadLine();
            MatchCollection matchedPhones = Regex.Matches(text, pattern1);

            string[] matched = matchedPhones
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", matched));
        }
    }
}
