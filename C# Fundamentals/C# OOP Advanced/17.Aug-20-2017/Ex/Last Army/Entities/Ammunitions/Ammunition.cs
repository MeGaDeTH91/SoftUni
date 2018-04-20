using System;

public abstract class Ammunition : IAmmunition
{
    private const double WearLevelMultiplier = 100.0d;

    private string name;

    private double weight;

    public Ammunition(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.WearLevel = this.Weight * WearLevelMultiplier;
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public double Weight
    {
        get { return this.weight; }
        private set { this.weight = value; }
    }

    public double WearLevel { get; protected set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}
