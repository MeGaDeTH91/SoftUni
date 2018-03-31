using System;
using System.Linq;
using System.Text;

namespace P01_ReverseArray
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            StringBuilder sb = new StringBuilder();
            ReverseMe(numbers, 0, sb);

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static void ReverseMe(int[] numbers, int index, StringBuilder sb)
        {
            if(index == numbers.Length)
            {
                return;
            }
            else
            {
                ReverseMe(numbers, index + 1, sb);
            }
            sb.Append(numbers[index] + " ");
        }
    }
}
