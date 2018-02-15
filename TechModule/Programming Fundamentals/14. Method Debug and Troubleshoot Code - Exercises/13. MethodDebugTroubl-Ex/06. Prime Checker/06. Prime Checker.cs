using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace _06.Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            bool trueOrNot = IsPrimeOrNot(n);
            Console.WriteLine(trueOrNot);
        }
        static bool IsPrimeOrNot(long n)
        {
            bool trueOrNot = true;
            long range = (long)Math.Sqrt(n);
            if(n == 2)
            {
                return true;
            }
            else if(n > 1)
            {
                for (int i = 2; i <= range; i++)
                {
                    if (n % i == 0)
                    {
                        return false;
                      
                    }
                }
            }
            else if(n <= 1)
            {
                return false;
            }
            return true;
        }
    }
}
