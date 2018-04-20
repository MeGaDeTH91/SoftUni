using System;
using System.Text;

public abstract class Harvester : IHarvester
{
    private const int InitialDurability = 1000;
    private const int DurabilityLossOnModeChange = 100;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double OreOutput { get; protected set; }

    public double EnergyRequirement { get; protected set; }

    public virtual double Durability { get; protected set; }

    public virtual void Broke()
    {
        this.Durability -= DurabilityLossOnModeChange;

        if(this.Durability < 0)
        {
            throw new ArgumentException();
        }
    }

    public double Produce()
    {
        return this.OreOutput;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(string.Format(Constants.InspectFirstLineFullTypeOfEntity, this.GetType().Name));

        sb.AppendLine(string.Format(Constants.InspectSecondLineDurability, this.Durability));

        return sb.ToString().Trim();
    }
}