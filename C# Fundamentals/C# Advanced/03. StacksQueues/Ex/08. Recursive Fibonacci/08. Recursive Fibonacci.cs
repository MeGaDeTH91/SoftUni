using System;
using System.Collections.Generic;

namespace _08._Recursive_Fibonacci
{
    class Program
    {
        private static long[] memo;

        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            memo = new long[n + 1];

            long fibNum = GetFibonacci(n);

            Console.WriteLine(fibNum);
        }

        private static long GetFibonacci(long n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (memo[n] != 0)
            {
                return memo[n];
            }

            memo[n] =
                    GetFibonacci(n - 1) +
                            GetFibonacci(n - 2);
            return memo[n];
        }
    }
}
