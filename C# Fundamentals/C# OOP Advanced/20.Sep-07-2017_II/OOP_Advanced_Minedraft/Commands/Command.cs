using System;
using System.Collections.Generic;

public abstract class Command : ICommand
{
    public IList<string> Arguments { get; }

    public Command(IList<string> arguments)
    {
        this.Arguments = arguments;
    }

    public abstract string Execute();
}
