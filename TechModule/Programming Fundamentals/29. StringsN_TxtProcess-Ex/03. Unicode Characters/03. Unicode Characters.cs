using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Unicode_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine()
                .ToArray();

            List<string> unicode = new List<string>();

            foreach (var item in input)
            {
                string currEl = GetEscapeSequence(item);
                unicode.Add(currEl);
            }
            Console.WriteLine(string.Join("", unicode));
        }

        private static string GetEscapeSequence(char c)
        {
            return "\\u" + ((int)c).ToString("x4");
        }

        
    }
}
