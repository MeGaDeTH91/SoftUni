using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                             .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                             .ToList();

            Action<List<string>> print = (array) => array.ForEach(x => Console.WriteLine($"Sir {x}"));

            print(input);
        }
    }
}
