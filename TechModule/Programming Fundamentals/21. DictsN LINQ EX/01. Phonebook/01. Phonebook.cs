using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var phonebook = new Dictionary<string, string>();

            var command = Console.ReadLine()
                .Split(' ')
                .ToArray();
            while (command[0] != "END")
            {
                if(command.Length == 3)
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
                if (command.Length == 2)
                {
                    var neededKey = command[1];
                    if (phonebook.ContainsKey(command[1]))
                    {
                        foreach (var item in phonebook)
                        {
                            if(item.Key == command[1])
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
