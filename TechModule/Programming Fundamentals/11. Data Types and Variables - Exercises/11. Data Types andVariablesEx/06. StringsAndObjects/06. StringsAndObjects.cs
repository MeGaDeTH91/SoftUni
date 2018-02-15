using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.StringsAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string one = Console.ReadLine();
            string two = Console.ReadLine();
            object both = one + " " + two;
            string final = (string)both;
            Console.WriteLine(final);
        }
    }
}
