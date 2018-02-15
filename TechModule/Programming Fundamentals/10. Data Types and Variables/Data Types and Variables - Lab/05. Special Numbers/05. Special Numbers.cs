using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            
            for (int i = 1; i <= n; i++)
            {
                //var k = int.Parse(Console.ReadLine());
                var ostatuk = i % 10;
                var i2 = i / 10;
                if(i == 5 || i == 7 || ostatuk + i2 == 5 || ostatuk + i2 == 7
                    || ostatuk + i2 == 11)
                {
                    Console.WriteLine("{0} -> True", i);
                }
                else
                {
                    Console.WriteLine("{0} -> False", i);
                }
            }
        }
    }
}
