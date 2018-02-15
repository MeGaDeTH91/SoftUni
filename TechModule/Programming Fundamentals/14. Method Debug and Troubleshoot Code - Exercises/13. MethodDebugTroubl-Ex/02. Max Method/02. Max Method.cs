using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Max_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            GetMax(num1, num2, num3);
        }
        static void GetMax (int num1, int num2, int num3)
        {
            int maxTemp = Math.Max(num1, num2);
            int max = Math.Max(maxTemp, num3);
            Console.WriteLine(max);
        }
    }
}
