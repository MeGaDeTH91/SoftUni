namespace _01.Fibonacci
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static List<int> numbers = new List<int>() { 0, 1 };
        private static int border = 0;

        public static void Main()
        {
            border = int.Parse(Console.ReadLine());

            int fiboNum = FindFibonacciNumber(border);

            Console.WriteLine(fiboNum);
        }

        private static int FindFibonacciNumber(int index)
        {
            if(index == 0)
            {
                return 0;
            }
            else if(index == 1)
            {
                return 1;
            }
            else
            {
                if(numbers.Count - 1 >= index)
                {
                    return numbers[index];
                }

                int currentNum = FindFibonacciNumber(index - 1) + FindFibonacciNumber(index - 2);
                numbers.Add(currentNum);

                return numbers[index];
            }
        }
    }
}
