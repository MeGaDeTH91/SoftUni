using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.DrawFilleSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            PrintTopRow(n);
            for (int j = 1; j < n - 1; j++)
            {
                PrintMiddleRows(n);
            }
            PrintBotRow(n);
        }
        static void PrintTopRow(int n)
        {
            Console.Write("{0}", new string('-', 2 * n));
            Console.WriteLine();
        }
        static void PrintMiddleRows(int n)
        {
            Console.Write("-");
            for (int i = 1; i <= n - 1; i++)
            {
                Console.Write("\\/");
            }
            Console.WriteLine("-");
        }
        static void PrintBotRow(int n)
        {
            Console.Write("{0}", new string('-', 2 * n));
            Console.WriteLine();
        }
    }
}
