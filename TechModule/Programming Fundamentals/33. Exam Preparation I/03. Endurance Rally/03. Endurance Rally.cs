using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Numerics;

namespace WorkProject1
{
    class Awards
    {
        public string Song { get; set; }
        public List<string> Award { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> drivers = Console.ReadLine()
                .Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<decimal> zones = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToList();

            List<long> checkptsIndex = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            foreach (var currDriver in drivers)
            {
                decimal fuel = currDriver.First();
                long ifNoReach = 0;
                int counter = 0;
                for (int i = 0; i < zones.Count; i++)
                {
                    decimal currZone = zones[i];
                    
                    if(checkptsIndex.Any(x => x == i) && currZone > 0 ||
                        checkptsIndex.All(x => x != i) && currZone < 0)
                    {
                        currZone = Math.Abs(currZone);
                        fuel += currZone;
                    }

                    else if (checkptsIndex.Any(x => x == i) && currZone < 0 ||
                        checkptsIndex.All(x => x != i) && currZone > 0)
                    {
                        currZone = Math.Abs(currZone);
                        if (fuel - currZone > 0)
                        {
                            fuel -= currZone;
                        }
                        else
                        {
                            counter++;
                            ifNoReach = i; // Зоната, в която горивото свършва
                            break;
                        }
                    }
                }
                if(counter > 0)
                {
                    Console.WriteLine($"{currDriver} - reached {ifNoReach}");
                }
                else
                {
                    Console.WriteLine($"{currDriver} - fuel left {fuel:F2}");
                }
            }
        }
    }
}
