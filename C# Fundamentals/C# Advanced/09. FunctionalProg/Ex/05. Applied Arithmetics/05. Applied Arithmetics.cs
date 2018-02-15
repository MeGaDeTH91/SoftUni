namespace _05._Applied_Arithmetics
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

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case"add":
                        initialNumbers = initialNumbers.Select(x => x = x + 1).ToList();
                        break;
                    case"multiply":
                        initialNumbers = initialNumbers.Select(x => x = x * 2).ToList();
                        break;
                    case"subtract":
                        initialNumbers = initialNumbers.Select(x => x = x - 1).ToList();
                        break;
                    case"print":
                        Console.WriteLine(string.Join(" ", initialNumbers));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
