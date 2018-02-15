using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Square_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> numbers = new List<int>();
            foreach (var currNum in input)
            {
                if(Math.Sqrt(currNum) == (int)Math.Sqrt(currNum))
                {
                    numbers.Add(currNum);
                }
            }
            numbers.Sort();
            numbers.Reverse();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
