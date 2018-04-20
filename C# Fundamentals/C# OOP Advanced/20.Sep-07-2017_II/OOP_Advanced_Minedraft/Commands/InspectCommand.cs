using System;
using System.Collections.Generic;
using System.Linq;

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
        int id = int.Parse(this.Arguments[0]);

        IHarvester harvester = (IHarvester)this.harvesterController.Entities.FirstOrDefault(x => x.ID == id);

        IProvider provider = (IProvider)this.providerController.Entities.FirstOrDefault(x => x.ID == id);

        if(harvester == null && provider == null)
        {
            return string.Format(Constants.InspectFailToFindEntity, id);
        }
        else if(provider == null)
        {
            return harvester.ToString();
        }
        else if (harvester == null)
        {
            return provider.ToString();
        }
        return string.Empty;
    }
}
