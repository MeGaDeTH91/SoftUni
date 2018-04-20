using System;
using System.Collections.Generic;

public class ModeCommand : Command
{
    private IHarvesterController harvesterController;

    public ModeCommand(IList<string> arguments, IHarvesterController harvesterController) : base(arguments)
    {
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        string newMode = this.Arguments[0];

        return this.harvesterController.ChangeMode(newMode);
    }
}
