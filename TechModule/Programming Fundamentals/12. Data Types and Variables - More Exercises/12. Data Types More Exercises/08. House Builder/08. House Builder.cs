using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.House_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            long price1 = long.Parse(Console.ReadLine());
            long price2 = long.Parse(Console.ReadLine());

            long sbytePrice = 0;
            long intPrice = 0;
            if(price1 >= sbyte.MinValue && price1 <= sbyte.MaxValue)
            {
                sbytePrice = price1 * 4;
                intPrice = price2 * 10;
            }
            else if (price1 >= int.MinValue && price1 <= int.MaxValue)
            {
                sbytePrice = price2 * 4;
                intPrice = price1 * 10;
            }
            long total = sbytePrice + intPrice;
            Console.WriteLine(total);
        }
    }
}
