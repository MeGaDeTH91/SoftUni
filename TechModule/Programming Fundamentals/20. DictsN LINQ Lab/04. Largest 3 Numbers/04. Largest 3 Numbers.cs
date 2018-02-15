using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numList = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .OrderByDescending(x => x)
                .ToList();  
                Console.WriteLine(string.Join(" ", numList.Take(3)));
        }
    }
}
