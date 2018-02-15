using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Training_Hall_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = double.Parse(Console.ReadLine());
            var itemNum = int.Parse(Console.ReadLine());
            var totalspent = 0.0;
            var startbudget = budget;
            var remainingmoney = 0.0;
            for (int i = 1; i <= itemNum; i++)
            {
                var itemName = Console.ReadLine();
                var itemPrice = double.Parse(Console.ReadLine());
                var itemCount = int.Parse(Console.ReadLine());
                totalspent = totalspent + (itemPrice * itemCount);
                if (itemCount > 1)
                {
                    Console.WriteLine("Adding {0} {1}s to cart.", itemCount, itemName);
                }
                else
                {
                    Console.WriteLine("Adding 1 {0} to cart.", itemName);
                }
            }
            remainingmoney = startbudget - totalspent;
            if (remainingmoney < 0)
            {
                Console.WriteLine("Subtotal: ${0:F2}", totalspent);
                var diff = totalspent - startbudget;
                Console.WriteLine("Not enough. We need ${0:F2} more.", diff);
            }
            else
            {
                Console.WriteLine("Subtotal: ${0:F2}", totalspent);
                Console.WriteLine("Money left: ${0:F2}", remainingmoney);
            }
            
        }
    }
}
