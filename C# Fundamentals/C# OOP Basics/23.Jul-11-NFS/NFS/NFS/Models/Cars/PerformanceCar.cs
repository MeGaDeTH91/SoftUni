using System;
using System.Collections.Generic;
using System.Text;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.addOns = new List<string>();
        this.IncreaseInitialHP();
        this.DecreaseInitialSuspension();
    }

    private void IncreaseInitialHP()
    {
        this.Horsepower += (this.Horsepower * 50) / 100;
    }
    private void DecreaseInitialSuspension()
    {
        this.Suspension -= (this.Suspension * 25) / 100;
    }
    public override void Tune(int tuneIndex, string addOn)
    {
        int horsePowerIncrease = tuneIndex;
        int suspensionIncrease = tuneIndex / 2;
        this.Horsepower += horsePowerIncrease;
        this.Suspension += suspensionIncrease;
        this.addOns.Add(addOn);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        if(this.addOns.Count > 0)
        {
            sb.AppendLine($"Add-ons: {string.Join(", ", this.addOns)}");
        }
        else if(this.addOns.Count == 0)
        {
            sb.AppendLine("Add-ons: None");
        }

        return sb.ToString().Trim();
    }
}
