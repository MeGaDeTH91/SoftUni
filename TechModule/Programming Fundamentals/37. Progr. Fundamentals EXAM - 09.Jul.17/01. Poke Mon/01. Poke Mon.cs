using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            byte y = byte.Parse(Console.ReadLine());
            decimal nStartingValue = n;
            decimal yValue = y;
            int targetPoked = 0;
            while (true)
            {
                if (n == nStartingValue * 50 / 100m && y != 0)
                {
                    n = n / y;
                }
                if (n - m >= 0)
                {
                    n = n - m;
                    targetPoked++;
                }
                else if (n - m < 0)
                {
                    Console.WriteLine(n);
                    Console.WriteLine(targetPoked);
                    return;
                }
            }

        }
    }
}
