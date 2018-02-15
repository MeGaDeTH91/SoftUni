using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = float.Parse(Console.ReadLine());
            var b = float.Parse(Console.ReadLine());

            var area = a * b;

            Console.WriteLine("{0:F2}", area);
        }
    }
}
