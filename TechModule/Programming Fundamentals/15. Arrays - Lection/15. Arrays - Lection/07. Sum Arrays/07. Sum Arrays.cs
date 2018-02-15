using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Sum_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] arr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = Math.Max(arr1.Length, arr2.Length);
            int[] sumArr = new int[n];

            for (int i = 0; i < n; i++)
            {
                sumArr[i] =
                    arr1[i % arr1.Length] +
                    arr2[i % arr2.Length];
                

            }
            Console.WriteLine(string.Join(" ", sumArr));
        }
    }
}
