using System;
using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester RegisterHarvester(string id, double oreOutput, double energyRequirement)
    {
        return new HammerHarvester(id, oreOutput, energyRequirement);
    }
    public Harvester RegisterHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
    {
        return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
    }

    public Harvester RegisterHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);

        if(type == "Sonic")
        {
            int sonicFactor = int.Parse(arguments[4]);
            return this.RegisterHarvester(id, oreOutput, energyRequirement, sonicFactor);
        }
        else
        {
            return this.RegisterHarvester(id, oreOutput, energyRequirement);
        }
    }
}
