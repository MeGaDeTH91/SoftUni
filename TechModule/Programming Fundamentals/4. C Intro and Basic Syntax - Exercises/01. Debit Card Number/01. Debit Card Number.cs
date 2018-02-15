using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Debit_Card_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());
            var d = int.Parse(Console.ReadLine());

            Console.Write("{0:D4} ", a);
            Console.Write("{0:D4} ", b);
            Console.Write("{0:D4} ", c);
            Console.Write("{0:D4}", d);
        }
    }
}
