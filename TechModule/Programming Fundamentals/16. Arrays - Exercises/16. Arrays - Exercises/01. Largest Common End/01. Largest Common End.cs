using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(' ').ToArray();
            string[] arr2 = Console.ReadLine().Split(' ').ToArray();
            int smallerArray = Math.Min(arr1.Length, arr2.Length);
            int leftCount = 0;
            int rightCount = 0;
            for (int i = 0; i < smallerArray; i++)
            {
               if(arr1[i] == arr2[i])
                {
                    leftCount++;
                }
               if(arr1[arr1.Length - 1 - i] == arr2[arr2.Length - 1 - i])
                {
                    rightCount++;
                }
            }
            Console.WriteLine(Math.Max(leftCount, rightCount));
        }
    }
}
