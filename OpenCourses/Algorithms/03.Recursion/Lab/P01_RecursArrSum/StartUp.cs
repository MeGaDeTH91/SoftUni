using System;
using System.Linq;

namespace P01_RecursArrSum
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sum = RecursiveSum(numbers, 0);

            Console.WriteLine(sum);
        }

        private static int RecursiveSum(int[] numbers, int index)
        {
            if(index == numbers.Length)
            {
                return 0;
            }

            return numbers[index] + RecursiveSum(numbers, index + 1);
        }
    }
}
