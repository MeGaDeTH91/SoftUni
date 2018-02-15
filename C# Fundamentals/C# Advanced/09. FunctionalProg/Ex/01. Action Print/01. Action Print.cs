using System;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                             .Split(new[] { ' '},StringSplitOptions.RemoveEmptyEntries)
                             .ToArray();
            Action<string[]> print = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            print(input);
        }
    }
}
