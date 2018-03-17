using System;
using System.Text;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;
    public int OverallPerformance => (this.Horsepower / this.Acceleration) + (this.Suspension + this.Durability);
    public int EnginePerformance => (this.Horsepower / this.Acceleration);
    public int SuspensionPerformance => (this.Suspension + this.Durability);
    private string status;
    public abstract void Tune(int tuneIndex, string addOn);
    public void DecreaseDurability(int laps, int length)
    {
        this.Durability -= laps * (length * length);
    }

    protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
        this.Status = "Ready";
    }

    public void SetNewStatus(string newStatus)
    {
        this.Status = newStatus;
    }
    public string Status
    {
        get { return this.status; }
        protected set { this.status = value; }
    }
    public string Brand
    {
        get { return this.brand; }
        protected set { this.brand = value; }
    }
    public string Model
    {
        get { return this.model; }
        protected set { this.model = value; }
    }
    public int YearOfProduction
    {
        get { return this.yearOfProduction; }
        protected set { this.yearOfProduction = value; }
    }
    public int Horsepower
    {
        get { return this.horsepower; }
        protected set { this.horsepower = value; }
    }
    public int Acceleration
    {
        get { return this.acceleration; }
        protected set { this.acceleration = value; }
    }
    public int Suspension
    {
        get { return this.suspension; }
        protected set { this.suspension = value; }
    }
    public int Durability
    {
        get { return this.durability; }
        protected set { this.durability = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}");
        sb.AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s");
        sb.AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");
        

        return sb.ToString().Trim();
    }
}
