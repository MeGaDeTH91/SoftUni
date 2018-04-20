using System;
using System.Text;

public abstract class Provider : IProvider
{
    private const double InitialDurability = 1000.0d;

    private const double DailyDurabilityDecrease = 100.0d;

    public Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double EnergyOutput { get; protected set; }

    public double Durability { get; protected set; }

    public void Broke()
    {
        this.Durability -= DailyDurabilityDecrease;
        if(this.Durability < 0)
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

        sb.AppendLine(string.Format(Constants.InspectEntityFullName, this.GetType().Name));
        sb.AppendLine(string.Format(Constants.InspectEntityDurability, this.Durability));

        return sb.ToString().Trim();
    }
}