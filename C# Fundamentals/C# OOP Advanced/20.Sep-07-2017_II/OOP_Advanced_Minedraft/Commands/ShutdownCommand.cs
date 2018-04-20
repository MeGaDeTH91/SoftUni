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
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(Constants.ShutdownFirstLineSystemShutdown);
        sb.AppendLine(string.Format(Constants.ShutdownSecondLineTotalEnergy, this.providerController.TotalEnergyProduced));
        sb.AppendLine(string.Format(Constants.ShutdownThirdLineTotalOre, this.harvesterController.OreProduced));

        return sb.ToString().Trim();
    }
}
