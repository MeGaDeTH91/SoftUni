using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int k = input.Length / 4;

            var left = input.Take(k).Reverse().ToArray();
            var right = input.Reverse().Take(k).ToArray();
            var row2 = input.Skip(k).Take(2 * k).ToArray();
            int[] row1 = left.Concat(right).ToArray();


            var sum = row1.Select((x, index) => x + row2[index]);
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
