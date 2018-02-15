using System;
using System.Collections.Generic;

namespace _09._Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Stack<long> fiboNums = new Stack<long>();

            fiboNums.Push(0);
            fiboNums.Push(1);

            long counter = 0;
            while (true)
            {
                if(counter< n - 1)
                {
                    long n1 = fiboNums.Pop();
                    long n2 = fiboNums.Peek();
                    fiboNums.Push(n1);

                    long currentFibo = n1 + n2;
                    fiboNums.Push(currentFibo);

                    counter++;
                }
                else
                {
                    break;
                }
            }
            long number = fiboNums.Pop();

            Console.WriteLine(number);
        }
    }
}
