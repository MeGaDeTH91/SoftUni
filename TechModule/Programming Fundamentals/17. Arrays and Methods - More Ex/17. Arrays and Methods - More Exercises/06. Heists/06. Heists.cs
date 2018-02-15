using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Heists
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] priceArr = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            long jewelPrice = priceArr[0];
            long goldPrice = priceArr[1];

            long totalEarning = 0;
            long totalExpenses = 0;

            for (int i = 1; i <= 20; i++)
            {
                string[] heist = Console.ReadLine().Split(' ').ToArray();
                if(heist[0] == "Jail" && heist[1] == "Time")
                {
                    break;
                }
                char[] heistloot = heist[0].ToCharArray();
                long heistExp = long.Parse(heist[1]);
                totalExpenses += heistExp;
                for (int k = 0; k < heistloot.Length; k++)
                {
                    if(heistloot[k] == '%')
                    {
                        totalEarning += jewelPrice;
                    }
                    else if (heistloot[k] == '$')
                    {
                        totalEarning += goldPrice;
                    }
                }
            }
            if(totalEarning >= totalExpenses)
            {
                Console.WriteLine("Heists will continue. Total earnings: {0}.", totalEarning - totalExpenses);
            }
            else
            {
          
                Console.WriteLine("Have to find another job. Lost: {0}.", totalExpenses - totalEarning); 
            }
        }
    }
}
