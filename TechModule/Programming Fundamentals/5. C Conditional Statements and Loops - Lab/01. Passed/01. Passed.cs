using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Passed
{
    class Program
    {
        static void Main(string[] args)
        {
            var grade = float.Parse(Console.ReadLine());

            if ( grade >= 3.00)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
