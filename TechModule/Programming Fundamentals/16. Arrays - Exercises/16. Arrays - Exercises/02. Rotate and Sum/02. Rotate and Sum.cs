using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Rotate_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = int.Parse(Console.ReadLine());
            int[] sumArray = new int[arr.Length];
            for (int i = 0; i < k; i++)
            {
                RotateArray(arr);
                for (int j = 0; j < arr.Length; j++)
                {
                    sumArray[j] += arr[j];
                }

            }
            Console.WriteLine(string.Join(" ", sumArray));  
                    
        }

        private static void RotateArray(int[] arr)
        {
            int lastElement = arr[arr.Length - 1];
            for (int i = arr.Length - 1; i > 0; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[0] = lastElement;
        }
    }
}
