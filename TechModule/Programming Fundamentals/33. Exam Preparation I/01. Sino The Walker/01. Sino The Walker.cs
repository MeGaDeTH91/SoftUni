using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;

namespace _01.Sino_The_Walker
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputTime = Console.ReadLine();
            DateTime startTime = DateTime.ParseExact(inputTime, "HH:mm:ss", CultureInfo.InvariantCulture);
            int steps = int.Parse(Console.ReadLine()) % 86400;
            int stepTime = int.Parse(Console.ReadLine()) % 86400;

            double addTime = steps * stepTime;
            startTime = startTime.AddSeconds(addTime);
            Console.WriteLine($"Time Arrival: {startTime.ToString("HH:mm:ss")}");
        }
    }
}
