using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PrintingTriangl
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int j = 1; j <= n; j++)
            {
                PrintTriangle(1, j);
            }
            for (int i = n-1; i > 0; i--)
            {
                PrintTriangle(1, i);
            }
        }
        static void PrintTriangle(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write($"{i} ");

            }
            Console.WriteLine();
        }
    }
}
