using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int k = arr1.Length / 4;
            int[] leftArr = new int[k];
            int[] middleArr = new int[2 * k];
            int[] rightArr = new int[k];

            int[] sumArray = new int[2 * k];

            for (int i = 0; i < k; i++)
            {
                leftArr[i] = arr1[i];

            }
            for (int i = 0; i < 2 * k; i++)
            {
                middleArr[i] = arr1[k + i];

            }
            for (int i = 0; i < k; i++)
            {
                rightArr[i] = arr1[3 * k + i];

            }
            Array.Reverse(leftArr);
            Array.Reverse(rightArr);
            for (int i = 0; i < k; i++)
            {
                sumArray[i] += middleArr[i] + leftArr[i];
                sumArray[i + k] += middleArr[i + k] + rightArr[i];
            }
            

            Console.WriteLine(string.Join(" ", sumArray));
        }
        //private static void RotateArray(int[] leftArr)
        //{
        //    int lastElement = leftArr[leftArr.Length - 1];
        //    for (int i = leftArr.Length - 1; i > 0; i--)
        //    {
        //        leftArr[i] = leftArr[i - 1];
        //    }
        //    leftArr[0] = lastElement;
        //}
    }
}
