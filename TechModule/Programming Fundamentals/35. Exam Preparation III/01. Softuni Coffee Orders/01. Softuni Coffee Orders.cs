using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _01.Softuni_Coffee_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal price = 0.0m;
            decimal total = 0.0m;
            for (int i = 0; i < n; i++)
            {
                decimal pricePerCap = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                long capsules = long.Parse(Console.ReadLine());

                int currMonthDays = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
                price = (currMonthDays * capsules) * pricePerCap;
                total += price;
                Console.WriteLine($"The price for the coffee is: ${price:F2}");
            }
            Console.WriteLine($"Total: ${total:F2}");
        }
    }
}
