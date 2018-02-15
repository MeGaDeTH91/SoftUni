using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Array_Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int min = int.MaxValue;
            int max = int.MinValue;
            double n = numArr.Length;
            int sum = 0;
            for (int i = 0; i < numArr.Length; i++)
            {
                sum = sum + numArr[i];
                if(numArr[i] > max)
                {
                    max = numArr[i];
                }
                if (numArr[i] < min)
                {
                    min = numArr[i];
                }

            }
            double average = sum / n;
            Console.WriteLine($"Min = {min}");
            Console.WriteLine($"Max = {max}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Average = {average}");
        }
    }
}
