using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = Console.ReadLine();
            string[] numbers = value.Split(' ');

            double[] array = new double[numbers.Length];

            double n = 0.0;
            for (int i = 0; i < numbers.Length; i++)
            {
                array[i] = double.Parse(numbers[i]);
                n = i;
            }
            for (int j = 0; j <= n; j++)
            {
                Console.WriteLine("{0} => {1}", array[j], Math.Round(array[j], MidpointRounding.AwayFromZero));
            }
        }
    }
}
