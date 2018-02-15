using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _01.Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            string text = Console.ReadLine();
            
           
            MatchCollection matchednames = Regex.Matches(text, pattern);
            foreach (Match item in matchednames)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine();
        }
    }
}
