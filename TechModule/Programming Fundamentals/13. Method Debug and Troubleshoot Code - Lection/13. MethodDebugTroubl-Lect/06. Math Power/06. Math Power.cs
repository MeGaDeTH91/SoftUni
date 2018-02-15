using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            double result = RaiseToPower(number, power);
            Console.WriteLine(result);
        }
        static double RaiseToPower(double number, int power)
        {
            double result = 0d;
            for (int i = 1; i <= power; i++)
            {
                result = Math.Pow(number, power);
            }
            return result;
        }
    }
}
