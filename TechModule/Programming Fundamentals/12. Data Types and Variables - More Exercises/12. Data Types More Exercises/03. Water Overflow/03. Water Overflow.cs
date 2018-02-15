using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            short litresInTank = 0;
            short capacityLeft = 255;
            for (int i = 1; i <= n; i++)
            {
                short litres = short.Parse(Console.ReadLine());
                capacityLeft = (short)(capacityLeft - litres);
                if (capacityLeft < 0)
                {
                    capacityLeft = (short)(capacityLeft + litres);
                    Console.WriteLine("Insufficient capacity!");
                }
                if (i == n)
                {
                    litresInTank = (short)(255 - capacityLeft);
                    Console.WriteLine(litresInTank);
                }
                
            }   
        }
    }
}
