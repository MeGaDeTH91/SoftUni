using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01.Charity_Marathon
{
    class Program
    {
        static void Main(string[] args)
        {
            int marDaysNum = int.Parse(Console.ReadLine());
            long runnersNum = long.Parse(Console.ReadLine());
            int avgLapsNum = int.Parse(Console.ReadLine());
            long trackLength = long.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());
            decimal moneyPerKm = decimal.Parse(Console.ReadLine());
            int restrictionsCap = marDaysNum * trackCapacity;
            if(runnersNum > restrictionsCap)
            {
                runnersNum = restrictionsCap;
            }

            decimal totalMeters = runnersNum * avgLapsNum * trackLength;
            decimal totalKm = totalMeters / 1000m;
            decimal moneyRaised = totalKm * moneyPerKm;
            Console.WriteLine($"Money raised: {moneyRaised:F2}");
        }
    }
}
