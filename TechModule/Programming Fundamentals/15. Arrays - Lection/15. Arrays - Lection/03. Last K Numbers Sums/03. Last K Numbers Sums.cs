using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Last_K_Numbers_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            long[] arr = new long[n];
            arr[0] = 1;

            for (int i = 1; i < n; i++)
            {
                long sum = 0;
                for (int prev = i - k; prev <= i - 1; prev++)
                {
                    if(prev >= 0)
                    {
                        sum = sum + arr[prev];
                    }
                    arr[i] = sum;
                }
            }
                
            Console.WriteLine(string.Join(" ", arr));

        }
    }
}
