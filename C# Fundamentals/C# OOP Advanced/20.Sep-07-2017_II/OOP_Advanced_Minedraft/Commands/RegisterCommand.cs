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
        string machineToRegister = this.Arguments[0];

        if (machineToRegister.Equals(Constants.HarvesterType))
        {
            return this.harvesterController.Register(this.Arguments.Skip(1).ToList());
        }
        else if (machineToRegister.Equals(Constants.ProviderType))
        {
            return this.providerController.Register(this.Arguments.Skip(1).ToList());
        }
        return string.Empty;
    }
}
