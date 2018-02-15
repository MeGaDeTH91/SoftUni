using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Extract_Middle_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = elements.Length;
            if(n == 1)
            {
                Console.Write("{ ");
                Console.Write(string.Join(" ", elements));
                Console.Write(" }");
            }
            else if(n % 2 == 0)
            {
                for (int i = n/2 -1; i <= n/2; i++)
                {
                    Console.Write("{ ");
                    Console.Write(string.Join(", ", elements[i]));
                    Console.Write(" }");
                }
            }
            else
            {
                for (int i = n / 2 - 1; i <= n / 2 + 1; i++)
                {
                    Console.Write("{ ");
                    Console.Write(string.Join(", ", elements[i]));
                    Console.Write(" }");
                }
            }
        }
    }
}
