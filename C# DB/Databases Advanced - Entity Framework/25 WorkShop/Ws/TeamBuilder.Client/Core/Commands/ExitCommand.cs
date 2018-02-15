using System;
using TeamBuilder.Client.Utilities;

namespace TeamBuilder.Client.Core.Commands
{
    public class ExitCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(0, inputArgs);

            Environment.Exit(0);

            return "Bye!";
        }
    }
}
