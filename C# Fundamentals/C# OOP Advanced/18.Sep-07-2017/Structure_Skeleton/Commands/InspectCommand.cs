using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InspectCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        StringBuilder result = new StringBuilder();

        int id = int.Parse(this.Arguments[0]);

        IProvider provider = (IProvider)((ProviderController)this.providerController).Entities.FirstOrDefault(x => x.ID == id);

        IHarvester harvester = (IHarvester)((HarvesterController)this.harvesterController).Entities.FirstOrDefault(x => x.ID == id);

        if (provider == null && harvester == null)
        {
            result.AppendLine(string.Format(Constants.InspectNoSuchEntity, id));
        }
        else if (provider == null)
        {
            result.AppendLine(harvester.ToString());
        }
        else if (harvester == null)
        {
            result.AppendLine(provider.ToString());
        }

        return result.ToString().Trim();
    }
}
