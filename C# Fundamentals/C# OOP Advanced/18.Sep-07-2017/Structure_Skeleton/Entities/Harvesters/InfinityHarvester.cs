﻿using System;

public class InfinityHarvester : Harvester
{
    private const double InitialDurability = 1000.0d;
    private const int OreOutputDivider = 10;

    private double durability;

    public InfinityHarvester(int id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput /= OreOutputDivider;
    }

    public override double Durability
    {
        get => this.durability;
        protected set => this.durability = Math.Max(0, value);
    }

    public override void Broke()
    {
        this.Durability = InitialDurability;
    }
}