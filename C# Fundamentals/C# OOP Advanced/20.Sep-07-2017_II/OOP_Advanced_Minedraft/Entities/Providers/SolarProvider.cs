using System;

public class SolarProvider : Provider
{
    private const int InitialDurabilityIncrease = 500;

    public SolarProvider(int id, double energyOutput) : base(id, energyOutput)
    {
        this.Durability += InitialDurabilityIncrease;
    }
}
