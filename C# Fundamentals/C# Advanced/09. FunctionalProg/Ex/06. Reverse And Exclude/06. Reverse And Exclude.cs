namespace _06._Reverse_And_Exclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<int> initialNumbers = Console.ReadLine()
                             .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToList();

            int divider = int.Parse(Console.ReadLine());

            Predicate<int> isDividable = number => number % divider == 0;

            Func<List<int>, List<int>> resutList = (numbers) => numbers.Where(x => !isDividable(x)).ToList();

            initialNumbers = resutList(initialNumbers);
            initialNumbers.Reverse();

            Console.WriteLine(string.Join(" ", initialNumbers));
        }
    }
}
