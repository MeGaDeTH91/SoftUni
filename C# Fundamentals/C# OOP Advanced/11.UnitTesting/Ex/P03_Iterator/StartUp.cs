using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace P03_Iterator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ListIterator listIterator = new ListIterator();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] commTokens = command.Split();

                    string currentCommand = commTokens[0];

                    switch (currentCommand)
                    {
                        case "Create":
                            listIterator = new ListIterator(commTokens.Skip(1).ToArray());
                            break;
                        case "Move":
                            Console.WriteLine(listIterator.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(listIterator.HasNext());
                            break;
                        case "Print":
                            listIterator.Print();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                } 

            }
        }
    }
}
