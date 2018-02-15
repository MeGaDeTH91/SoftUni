using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                                 .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .ToList();

            Func<string, int, bool> triFunction = (name, number) =>
            {
                int sum = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    sum += name[i];
                }
                if(sum >= number)
                {
                    return true;
                }
                return false;
            };

            Func<List<string>, int, Func<string, int, bool>, string> firstValidName = (arr, number, func) => arr
 .FirstOrDefault(str => func(str, number));

            string desiredName = firstValidName(names, num, triFunction);

            Console.WriteLine(desiredName);
        }
    }
}
