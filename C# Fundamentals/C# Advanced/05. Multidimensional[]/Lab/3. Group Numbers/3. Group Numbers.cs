using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] zero = input.Where(x => x % 3 == 0).ToArray();
            int[] one = input.Where(x => Math.Abs(x % 3) == 1).ToArray();
            int[] two = input.Where(x => Math.Abs(x % 3) == 2).ToArray();

            int[][] jaggedArr = new int[3][];

            jaggedArr[0] = zero;
            jaggedArr[1] = one;
            jaggedArr[2] = two;

            foreach (var arr in jaggedArr)
            {
                Console.WriteLine(string.Join(" ", arr));
            }

            //2-ри начин, моя начин
            //int[] input = Console.ReadLine()
            //    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();

            //List<int> zero = new List<int>(input.Where(x => x % 3 == 0));
            //List<int> one = new List<int>(input.Where(x => Math.Abs(x % 3) == 1));
            //List<int> two = new List<int>(input.Where(x => Math.Abs(x % 3) == 2));

            //int[][] jaggedArr = new int[3][];

            //for (int i = 0; i < 1; i++)
            //{
            //    jaggedArr[i] = new int[zero.Count];
            //    for (int j = 0; j < zero.Count; j++)
            //    {
            //        jaggedArr[i][j] = zero[j];
            //    }
            //}
            //for (int i = 1; i < 2; i++)
            //{
            //    jaggedArr[i] = new int[one.Count];
            //    for (int j = 0; j < one.Count; j++)
            //    {
            //        jaggedArr[i][j] = one[j];
            //    }
            //}
            //for (int i = 2; i < 3; i++)
            //{
            //    jaggedArr[i] = new int[two.Count];
            //    for (int j = 0; j < two.Count; j++)
            //    {
            //        jaggedArr[i][j] = two[j];
            //    }
            //}

            //for (int rows = 0; rows < jaggedArr.Length; rows++)
            //{
            //    var row = jaggedArr[rows];

            //    for (int i = 0; i < row.Length; i++)
            //    {
            //        Console.Write($"{row[i]} ");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
