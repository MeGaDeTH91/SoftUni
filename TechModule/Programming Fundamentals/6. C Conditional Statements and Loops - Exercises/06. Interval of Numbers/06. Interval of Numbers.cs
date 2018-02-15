using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Interval_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());

            if (a > b)
            {
                var start = b;
                var end = a;
                for (int i = start; i <= end; i++)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                var start = a;
                var end = b;
                for (int i = start; i <= end; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
