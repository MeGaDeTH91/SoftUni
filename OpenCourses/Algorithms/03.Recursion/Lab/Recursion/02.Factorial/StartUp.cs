namespace _02.Factorial
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int factorial = Factorial(number);

            Console.WriteLine(factorial);
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
