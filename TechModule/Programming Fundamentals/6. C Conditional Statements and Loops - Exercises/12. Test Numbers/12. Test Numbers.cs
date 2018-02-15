using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Test_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            var maxsum = int.Parse(Console.ReadLine());
            var tempsum = 0;
            var totalsum = 0;
            var counter = 0;

            for (int i = n; i >= 1; i--)
            {
                
                for (int k = 1; k <= m; k++)
                {
                    tempsum = (i * k) * 3;
                    totalsum = totalsum + tempsum;
                    counter++;

                    if (totalsum >= maxsum)
                    {
                        Console.WriteLine("{0} combinations", counter);
                        Console.WriteLine("Sum: {0} >= {1}", totalsum, maxsum);
                        return;
                    } 
                    
                }
               
            }
            Console.WriteLine("{0} combinations", counter);
            Console.WriteLine("Sum: {0}", totalsum);
            return;
        }
    }
}
