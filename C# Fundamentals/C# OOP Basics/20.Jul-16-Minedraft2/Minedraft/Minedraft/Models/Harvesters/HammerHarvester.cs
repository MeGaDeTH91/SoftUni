using System;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput += this.OreOutput * (200.0d / 100.0d);
        this.EnergyRequirement += this.EnergyRequirement * (100.0d / 100.0d);
    }


}
