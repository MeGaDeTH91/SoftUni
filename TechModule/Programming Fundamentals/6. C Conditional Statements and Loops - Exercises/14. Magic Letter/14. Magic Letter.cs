using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Magic_Letter
{
    class Program
    {
        static void Main(string[] args)
        {
            var startLetter = Console.ReadLine();
            var endLetter = Console.ReadLine();
            var skipLetter = Console.ReadLine();

            char start = startLetter[0];
            char end = endLetter[0];
            char skip = skipLetter[0];


            for (char i = start; i <= end; i++)
            {
                for (char j = start; j <= end; j++)
                {
                    for (char k = start; k <= end; k++)
                    {
                        if (i != skip && j != skip && k != skip)
                        {
                            Console.Write("{0}{1}{2} ", i, j, k);
                        }
                    }
                }
            }
        }
    }
}
