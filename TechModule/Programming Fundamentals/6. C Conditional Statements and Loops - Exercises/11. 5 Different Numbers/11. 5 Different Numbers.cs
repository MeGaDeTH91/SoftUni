using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._5_Different_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());
            var counter = 0;
            for (int n1 = start; n1 <= end; n1++)
            {
                for (int n2 = start; n2 <= end; n2++)
                {
                    for (int n3 = start; n3 <= end; n3++)
                    {
                        for (int n4 = start; n4 <= end; n4++)
                        {
                            for (int n5 = start; n5 <= end; n5++)
                            {
                                if (start <= n1 && n1 < n2 && n2 < n3 && n3< n4 && n4 < n5 && n5 <= end)
                                {
                                    counter++;
                                    Console.WriteLine("{0} {1} {2} {3} {4}", n1, n2, n3, n4, n5);
                                }
                                
                            }
                        }
                    }
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
