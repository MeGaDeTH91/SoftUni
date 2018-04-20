using System;

public class PressureProvider : Provider
{
    private const int InitialDurabilityDecrease = 300;
    private const int InitialEnergyOutputMultiPlier = 2;

    public PressureProvider(int iD, double energyOutput) : base(iD, energyOutput)
    {
        this.Durability -= InitialDurabilityDecrease;
        this.EnergyOutput *= InitialEnergyOutputMultiPlier;
    }
}
