using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_SortWords
{
    class P02_SortWords
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();

            Console.WriteLine(string.Join(" ", words.OrderBy(x => x)));
        }
    }
}
