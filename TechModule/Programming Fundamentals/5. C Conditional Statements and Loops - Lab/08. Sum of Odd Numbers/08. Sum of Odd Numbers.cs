using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            n = n * 2;
            
            var sum = 0;
            var counter = 0;
            for (int i = 1; i <= n; i++)
            {
                if(i % 2 > 0)
                {
                    counter++;
                    sum = sum + i;
                    Console.WriteLine(i);
                }
                
            }
            Console.WriteLine("Sum: {0}", sum);
        }
    }
}
