using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sweet_Dessert
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal cash = decimal.Parse(Console.ReadLine());
            long guestNum = long.Parse(Console.ReadLine());
            decimal bananaPrice = decimal.Parse(Console.ReadLine());
            decimal eggPrice = decimal.Parse(Console.ReadLine());
            decimal kgBerry = decimal.Parse(Console.ReadLine());

            long portionsNum = guestNum / 6;
            if(guestNum % 6 > 0)
            {
                portionsNum++;
            }
            decimal onePortion = (2 * bananaPrice) + (4 * eggPrice) + (0.2m * kgBerry);
            decimal total = portionsNum * onePortion;
            if(cash >= total)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {total:F2}lv.");
            }
            else
            {
                decimal diff = total - cash;
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {diff:F2}lv more.");
            }
        }
    }
}
