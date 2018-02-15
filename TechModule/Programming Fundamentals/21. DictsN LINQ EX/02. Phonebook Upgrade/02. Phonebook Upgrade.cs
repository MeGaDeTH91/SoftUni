using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Phonebook_Upgrade
{
    class Program
    {
        static void Main(string[] args)
        {
            var phonebook = new SortedDictionary<string, string>();

            var command = Console.ReadLine()
                .Split(' ')
                .ToArray();
            while (command[0] != "END")
            {
                if(command[0] == "ListAll")
                {
                    foreach (var item in phonebook)
                    {
                        Console.WriteLine($"{item.Key} -> {item.Value}");
                    }
                }
                if (command.Length == 3)
                {
                    if (phonebook.ContainsKey(command[1]))
                    {
                        phonebook[command[1]] = command[2];
                    }
                    else
                    {
                        phonebook[command[1]] = command[2];
                    }
                }
                else if (command.Length == 2)
                {
                    var neededKey = command[1];
                    if (phonebook.ContainsKey(command[1]))
                    {
                        foreach (var item in phonebook)
                        {
                            if (item.Key == command[1])
                                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
                        }

                    }
                    else
                    {
                        Console.WriteLine($"Contact {command[1]} does not exist.");

                    }
                }
                command = Console.ReadLine()
               .Split(' ')
               .ToArray();
            }
        }
    }
}
