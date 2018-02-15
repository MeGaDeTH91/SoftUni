using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Fibonacci_Num
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            if (n == 0)
                Console.WriteLine("1");
            else
            {
                long fibNum = PrintFib(n);
                Console.WriteLine(fibNum);
            }
            
            
        }
        static long PrintFib(long n)
        { 
        long tempFib1 = 0;
        long tempFib2 = 1;

        long fibNum = 1;
            
        for (int i = 1; i <= n; i++)
            {
                fibNum = tempFib1 + tempFib2;
                if (tempFib1<tempFib2)
                {
                    tempFib1 = fibNum;
                    
                }
                else
                {
                    tempFib2 = fibNum;
                }

            }
            return fibNum;
        }
    }
}
