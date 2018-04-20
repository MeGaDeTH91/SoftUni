using System;
using System.Text;

public abstract class Provider : IProvider
{
    private const int InitialDurability = 1000;

    private const int DurabilityLossOnDay = 100;

    public Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public double EnergyOutput { get; protected set; }

    public int ID { get; }

    public double Durability { get; protected set; }

    public void Broke()
    {
        this.Durability -= DurabilityLossOnDay;

        if (this.Durability < 0)
        {
            throw new ArgumentException();
        }
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(string.Format(Constants.InspectFirstLineFullTypeOfEntity, this.GetType().Name));

        sb.AppendLine(string.Format(Constants.InspectSecondLineDurability, this.Durability));

        return sb.ToString().Trim();
    }
}