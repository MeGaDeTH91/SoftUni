using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.VariableinHexForm
{
    class Program
    {
        static void Main(string[] args)
        {
            var hexnum = Console.ReadLine();

            var b = Convert.ToInt32($"{hexnum}" ,16);
            Console.WriteLine(b);
        }
    }
}
