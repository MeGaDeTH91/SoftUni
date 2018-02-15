using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Min__Max__Sum__Average
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list1 = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                list1.Add(currNum);
            }
            Console.WriteLine("Sum = {0}", list1.Sum());
            Console.WriteLine("Min = {0}", list1.Min());
            Console.WriteLine("Max = {0}", list1.Max());
            Console.WriteLine("Average = {0}", list1.Average());
        }
    }
}
