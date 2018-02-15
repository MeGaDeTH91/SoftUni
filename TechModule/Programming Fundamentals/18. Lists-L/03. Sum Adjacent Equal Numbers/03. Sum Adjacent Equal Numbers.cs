using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> numbers = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if(numbers[i] == numbers[i + 1])
                {
                    decimal desiredNum = numbers[i] * 2;
                    numbers.RemoveAt(i);
                    numbers.RemoveAt(i);
                    numbers.Insert(i, desiredNum);
                    i = -1;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
