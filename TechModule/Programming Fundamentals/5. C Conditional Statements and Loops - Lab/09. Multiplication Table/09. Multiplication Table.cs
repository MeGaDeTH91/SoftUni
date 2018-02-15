using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var result = 0;
            for (int times = 1; times <= 10; times++)
            {
                result = n * times;
                Console.WriteLine("{0} X {1} = {2}", n, times, result);
            }

        }
    }
}
