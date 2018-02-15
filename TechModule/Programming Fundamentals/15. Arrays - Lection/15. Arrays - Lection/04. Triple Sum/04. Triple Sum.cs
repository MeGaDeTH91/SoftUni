using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Triple_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string values = Console.ReadLine();
            string[] nums = values.Split(' ');

            int[] arr = new int[nums.Length];
            int n = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                arr[i] = int.Parse(nums[i]);
                n = i;
            }
            int counter = 0;
            int sum = 0;
            //Console.WriteLine(string.Join(" ", arr));
            for (int a = 0; a < n; a++)
            {
                for (int b = a + 1; b <= n; b++)
                {
                    sum = arr[a] + arr[b];
                    if(arr.Contains(sum))
                    {
                        Console.WriteLine("{0} + {1} == {2}", arr[a], arr[b], sum);
                        counter++;
                    }   
                }
            }
            if(counter == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
