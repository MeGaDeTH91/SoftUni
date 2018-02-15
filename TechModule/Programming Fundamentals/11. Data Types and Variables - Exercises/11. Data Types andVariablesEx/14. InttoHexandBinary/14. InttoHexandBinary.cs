using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.InttoHexandBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());

            string hexvalue = a.ToString("X");
            string binary = Convert.ToString(a, 2);
            Console.WriteLine(hexvalue);
            Console.WriteLine(binary);
        }
    }
}
