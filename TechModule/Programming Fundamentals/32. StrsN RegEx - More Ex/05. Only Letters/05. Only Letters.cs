using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _05.Only_Letters
{
    class Program
    {
        public object Assert { get; private set; }

        static void Main(string[] args)
        {
            string pattern = @"(?<digits>[0-9]+)(?<letter>[A-Za-z])";
            string input = Console.ReadLine();
            
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match m in matches)
            {
                input = input.Replace(
                    m.Groups["digits"].Value, m.Groups["letter"].Value);
            }
            Console.WriteLine(input);
        }
        
    }
}
