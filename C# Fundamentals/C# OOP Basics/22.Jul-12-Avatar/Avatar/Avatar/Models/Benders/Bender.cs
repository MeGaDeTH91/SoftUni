using System;

public abstract class Bender
{
    private string name;
    private int power;
    public abstract double TotalPower { get; }

    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public int Power
    {
        get { return this.power; }
        protected set { this.power = value; }
    }
    
    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }
}
