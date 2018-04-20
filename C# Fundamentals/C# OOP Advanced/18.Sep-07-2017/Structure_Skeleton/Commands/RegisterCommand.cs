using System;
using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string machineType = this.Arguments[0];

        if (machineType.Equals("Harvester"))
        {
            return this.harvesterController.Register(this.Arguments.Skip(1).ToList());
        }
        else if (machineType.Equals("Provider"))
        {
            return this.providerController.Register(this.Arguments.Skip(1).ToList());
        }
        else
        {
            return string.Empty;
        }
    }
}
