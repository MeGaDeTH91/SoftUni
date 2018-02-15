using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _06.Replace_a_Tag
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = Console.ReadLine();

            while (url != "end")
            {
                string pattern = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
                string replacement = @"[URL href=$1]$2[/URL]";
                
                string matches = Regex.Replace(url, pattern, replacement);

                Console.WriteLine(matches);

                url = Console.ReadLine();
            }
           
        }
    }
}
