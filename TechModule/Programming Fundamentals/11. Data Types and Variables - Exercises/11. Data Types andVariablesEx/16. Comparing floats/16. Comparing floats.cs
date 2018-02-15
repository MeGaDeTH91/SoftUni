using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Comparing_floats
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            bool equalOrNot = false;
            double difference = Math.Abs(a - b);
            if(difference >= 0.000001)
            {
                Console.WriteLine(equalOrNot);
            }
            else
            {
                equalOrNot = true;
                Console.WriteLine(equalOrNot);
            }
        }
    }
}
