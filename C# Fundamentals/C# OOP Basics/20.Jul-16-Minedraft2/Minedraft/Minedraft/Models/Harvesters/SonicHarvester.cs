using System;

public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public int SonicFactor
    {
        get { return sonicFactor; }
        set { sonicFactor = value; }
    }

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement /= this.SonicFactor;
    }
}
