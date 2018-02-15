using System;

namespace _11.Odd_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                var n = int.Parse(Console.ReadLine());

                if (n % 2 == 0)
                {
                    Console.WriteLine("Please write an odd number.");
                }
                else
                {
                    Console.WriteLine("The number is: {0}", Math.Abs(n));
                    return;
                }
            }
        }
    }
}
