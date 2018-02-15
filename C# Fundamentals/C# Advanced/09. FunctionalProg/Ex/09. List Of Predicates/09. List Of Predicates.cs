using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            List<int> divisables = Console.ReadLine()
                                   .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToList();

            List<int> result = new List<int>();
            Predicate<int> predicate = number =>
            {
                foreach (var item in divisables)
                {
                    if(number % item != 0)
                    {
                        return false;
                    }
                }
                return true;
            };

            for (int i = 1; i <= num; i++)
            {
                
                if (predicate(i))
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
