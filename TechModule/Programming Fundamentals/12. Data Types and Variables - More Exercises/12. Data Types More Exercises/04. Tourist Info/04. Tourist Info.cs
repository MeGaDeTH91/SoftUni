using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Tourist_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            string impUnit = Console.ReadLine();
            double inValue = double.Parse(Console.ReadLine());

            double result = 0.0d;
            switch (impUnit)
            {
                case "miles":
                    result = inValue * 1.6;
                    Console.WriteLine($"{inValue} {impUnit} = {result:F2} kilometers");
                    break;
                case "inches":
                    result = inValue * 2.54;
                    Console.WriteLine($"{inValue} {impUnit} = {result:F2} centimeters");
                    break;
                case "feet":
                    result = inValue * 30;
                    Console.WriteLine($"{inValue} {impUnit} = {result:F2} centimeters");
                    break;
                case "yards":
                    result = inValue * 0.91;
                    Console.WriteLine($"{inValue} {impUnit} = {result:F2} meters");
                    break;
                case "gallons":
                    result = inValue * 3.8;
                    Console.WriteLine($"{inValue} {impUnit} = {result:F2} liters");
                    break;
                default:
                    break;
            }
        }
    }
}
