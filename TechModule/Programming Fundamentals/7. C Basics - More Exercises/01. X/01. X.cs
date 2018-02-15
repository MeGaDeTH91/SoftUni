using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.X
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            
            
                
                    Console.WriteLine("x{0}x", new string(' ', n - 2)); // Top
            for (int k = 1; k <= (n - 3) / 2; k++)
            {
                Console.WriteLine("{0}x{1}x{0}", new string(' ', k), new string(' ', n - 2 * k - 2));
            }
            Console.WriteLine("{0}x{0}", new string(' ', (n - 1) / 2)); // Center
            for (int k = (n -3) / 2; k >= 1; k--)
            {
                Console.WriteLine("{0}x{1}x{0}", new string(' ', k), new string(' ', n - 2 * k - 2));
            }
            Console.WriteLine("x{0}x", new string(' ', n - 2)); // Bottom


        }
    }
}
