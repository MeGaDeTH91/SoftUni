using System;
using System.Collections.Generic;
using System.Text;

namespace BusTicketSystem.Client.Core.Commands
{
    public class ExitCommand
    {
        public static string Execute(string[] data)
        {
            Console.WriteLine("Have a good day!");
            Environment.Exit(0);
            return string.Empty;
        }
    }
}
