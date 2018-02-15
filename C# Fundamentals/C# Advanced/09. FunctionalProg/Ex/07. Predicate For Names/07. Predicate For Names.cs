using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                                 .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .ToList();

            Predicate<string> nameExclude = name => name.Length <= length;

            names = names.Where(x => nameExclude(x)).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
