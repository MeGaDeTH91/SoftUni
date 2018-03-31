using System;

namespace P02_RecursiveFactorial
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int factorialNumber = Factorial(number);

            Console.WriteLine(factorialNumber);
        }

        private static int Factorial(int number)
        {
            if(number == 1)
            {
                return 1;
            }
            return number * Factorial(number - 1);
        }
    }
}
