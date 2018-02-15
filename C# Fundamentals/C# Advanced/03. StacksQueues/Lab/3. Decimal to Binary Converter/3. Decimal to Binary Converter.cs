using System;
using System.Collections.Generic;

namespace _3._Decimal_to_Binary_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Stack<int> currStack = new Stack<int>();

            if(num == 0)
            {
                Console.WriteLine(0);
                return;
            }
            else
            {
                while (num > 0)
                {
                    int remainder = (int)num % 2;
                    num /= 2;
                    currStack.Push(remainder);
                }
            }
            Console.WriteLine(string.Join("", currStack));
        }
    }
}
