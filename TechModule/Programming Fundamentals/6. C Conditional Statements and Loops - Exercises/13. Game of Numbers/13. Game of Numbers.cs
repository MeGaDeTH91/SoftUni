using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Game_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstn = int.Parse(Console.ReadLine());
            var secondn = int.Parse(Console.ReadLine());
            var magicn = int.Parse(Console.ReadLine());
            var counter = 0;
            var magicA = 0;
            var magicB = 0;

            for (int i = firstn; i <= secondn; i++)
            {
                for (int k = firstn; k <= secondn; k++)
                {
                    counter++;
                    if (i + k == magicn)
                    {
                        magicA = i;
                        magicB = k;

                    }
                }
            }
            if (magicA > 0)
            {
                Console.WriteLine("Number found! {0} + {1} = {2}", magicA, magicB, magicn);
            }
            else
            {
                Console.WriteLine("{0} combinations - neither equals {1}", counter, magicn);
            }
        }
    }
}
