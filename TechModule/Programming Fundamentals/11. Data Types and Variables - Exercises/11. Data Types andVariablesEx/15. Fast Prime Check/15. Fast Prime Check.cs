using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Fast_Prime_Check
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int numberCount = 2; numberCount <= number; numberCount++)
            {
                bool primeOrNot = true;

                for (int range = 2; range <= Math.Sqrt(numberCount); range++)
                {
                    if (numberCount % range == 0)
                    {
                        primeOrNot = false;
                        break;
                    }
                }
                Console.WriteLine($"{numberCount} -> {primeOrNot}");
            }
        }
    }
}
