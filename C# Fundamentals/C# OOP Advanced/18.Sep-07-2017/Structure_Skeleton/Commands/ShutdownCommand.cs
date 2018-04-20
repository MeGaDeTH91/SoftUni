using System;
using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine(Constants.SystemShutDownMessage);
        result.AppendLine(string.Format(Constants.SystemShutDownTotalEnergy, this.providerController.TotalEnergyProduced));
        result.AppendLine(string.Format(Constants.SystemShutDownTotalOre, this.harvesterController.TotalOreProduced));

        return result.ToString().Trim();
    }
}
