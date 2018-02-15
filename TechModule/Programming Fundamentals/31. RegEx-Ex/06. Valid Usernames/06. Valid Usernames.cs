using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _06.Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string[] input = line.Split(new char[] { ' ', '\\', '/', '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string pattern = @"^[a-zA-Z][a-zA-Z0-9_]{2,24}$";

        }
    }
}
