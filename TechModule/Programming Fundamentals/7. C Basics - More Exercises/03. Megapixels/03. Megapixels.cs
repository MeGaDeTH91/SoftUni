using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Megapixels
{
    class Program
    {
        static void Main(string[] args)
        {
            var w = int.Parse(Console.ReadLine());
            var h = int.Parse(Console.ReadLine());

            double result = (w * h) / 1000000.0;
            double pixels = Math.Round(result, 1);
            Console.WriteLine("{0}x{1} => {2}MP", w, h, pixels);
        }
    }
}
