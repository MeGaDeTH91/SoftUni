using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01.Hornet_Wings
{
    class Program
    {
        static void Main(string[] args)
        {
            long hornetFlaps = long.Parse(Console.ReadLine());
            decimal distance = decimal.Parse(Console.ReadLine());
            long endurance = long.Parse(Console.ReadLine());
            decimal distLength = (hornetFlaps / 1000.0m) * distance;
            long flapTime = hornetFlaps / 100;
            long restTime = (hornetFlaps / endurance) * 5;
            long finalTime = flapTime + restTime;

            Console.WriteLine($"{distLength:F2} m.");
            Console.WriteLine($"{finalTime} s.");
        }
    }
}
