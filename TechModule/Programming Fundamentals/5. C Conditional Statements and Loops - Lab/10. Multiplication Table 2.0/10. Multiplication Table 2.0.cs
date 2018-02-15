using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var start = int.Parse(Console.ReadLine());

            var result = 0;
            for (int times = start; times <= 10; times++)
            {
                result = n * times;
                Console.WriteLine("{0} X {1} = {2}", n, times, result);
            }
            if (start > 10)
            {
                result = n * start;
                Console.WriteLine("{0} X {1} = {2}", n, start, result);
            }
        }
    }
}
