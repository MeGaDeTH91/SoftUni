using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03.Match_Hexadecimal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?:0x)?[0-9A-F]+\b";
            string text = Console.ReadLine();

            MatchCollection matches = Regex.Matches(text, pattern);
            string[] outputs = matches
                .Cast<Match>()
                .Select(x => x.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(" ", outputs));
        }
    }
}
