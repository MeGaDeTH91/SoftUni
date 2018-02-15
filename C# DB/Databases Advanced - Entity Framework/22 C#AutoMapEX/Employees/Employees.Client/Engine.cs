using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employees.Client
{
    internal class Engine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        internal void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    string[] commandTokens = input.Split(' ');

                    string commandName = commandTokens[0];

                    string[] commandArgs = commandTokens.Skip(1).ToArray();

                    var command = CommandParser.ParseCommand(serviceProvider, commandName);

                    var result = command.Execute(commandArgs);

                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }                
            }
        }
    }
}
