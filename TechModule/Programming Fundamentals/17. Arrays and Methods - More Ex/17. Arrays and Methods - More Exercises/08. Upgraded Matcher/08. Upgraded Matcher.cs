using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Upgraded_Matcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] prodNames = Console.ReadLine().Split(' ').ToArray();
            long[] quantities = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            decimal[] prices = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

            int tempmax = Math.Max(prodNames.Length, quantities.Length);
            int max = Math.Max(tempmax, prices.Length);

            decimal currResult = 0.0m;
            

            if (prodNames.Length < max || quantities.Length < max)
            {
                Array.Resize(ref quantities, max);
                Array.Resize(ref prodNames, max);
            }
            
            int currIndex = -1;
            for (int i = 0; i < 20; i++)
            {
                
                string[] inputArr = Console.ReadLine().Split(' ').ToArray();
                string currName = inputArr[0];
                if (currName == "done")
                {
                    break;
                }

                long currQuantity = long.Parse(inputArr[1]);

                currIndex = Array.IndexOf(prodNames, currName);
                long quanCheck = quantities[currIndex];
                quantities[currIndex] = quantities[currIndex] - currQuantity;
                if(quantities[currIndex] >= 0)
                {
                    currResult = currQuantity * prices[currIndex];
                    Console.WriteLine($"{prodNames[currIndex]} x {currQuantity} costs {currResult:F2}");
                    
                }
                else
                {
                    quantities[currIndex] = quanCheck;
                    Console.WriteLine($"We do not have enough {prodNames[currIndex]}");
                }
                
            }
        }
    }
}
