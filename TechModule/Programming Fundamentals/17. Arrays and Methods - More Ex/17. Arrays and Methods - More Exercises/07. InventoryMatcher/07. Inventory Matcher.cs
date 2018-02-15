using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.InventoryMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] prodNames = Console.ReadLine().Split(' ').ToArray();
            long[] quantities = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            decimal[] prices = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

            int currIndex = -1;
            for (int i = 0; i < 20; i++)
            {
                string currName = Console.ReadLine();
                if(currName == "done")
                {
                    break;
                }
                currIndex = Array.IndexOf(prodNames, currName);
                Console.WriteLine("{0} costs: {1}; Available quantity: {2}", 
                    prodNames[currIndex], prices[currIndex], quantities[currIndex]);
            }


        }
    }
}
