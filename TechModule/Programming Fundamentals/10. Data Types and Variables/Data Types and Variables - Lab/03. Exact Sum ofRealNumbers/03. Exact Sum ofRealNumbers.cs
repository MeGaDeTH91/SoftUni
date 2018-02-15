using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Exact_Sum_ofRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var sum = 0m;
            for (int i = 1; i <= n; i++)
            {
                var k = decimal.Parse(Console.ReadLine());
                sum = sum + k; 
            }
            Console.WriteLine("{0}", sum);
        }
    }
}
