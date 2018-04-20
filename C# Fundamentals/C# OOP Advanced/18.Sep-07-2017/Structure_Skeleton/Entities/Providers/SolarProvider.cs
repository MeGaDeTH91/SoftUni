using System;

public class SolarProvider : Provider
{
    private const int InitialDurabilityIncrease = 500;

    public SolarProvider(int iD, double energyOutput) : base(iD, energyOutput)
    {
        this.Durability += InitialDurabilityIncrease;
    }
}
