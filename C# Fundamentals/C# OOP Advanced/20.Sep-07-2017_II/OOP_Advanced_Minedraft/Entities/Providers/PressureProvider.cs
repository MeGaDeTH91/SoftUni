using System;

public class PressureProvider : Provider
{
    private const int InitialDurabilityDecrease = 300;
    private const int EnergyOutputMultiply = 2;

    public PressureProvider(int id, double energyOutput) : base(id, energyOutput)
    {
        this.Durability -= InitialDurabilityDecrease;
        this.EnergyOutput *= EnergyOutputMultiply;
    }
}
