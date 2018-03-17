using System;
using System.Collections.Generic;

public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;
    private string status;

    public string Status
    {
        get { return status; }
        set { status = value; }
    }
    
    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public void ReduceFuel(int trackLength)
    {
        this.Car.ReduceFuel(trackLength, this.FuelConsumptionPerKm);
    }

    public void IncreaseTime(int trackLength)
    {
        this.TotalTime += 60.0d / (trackLength / this.Speed);
    }

    public void OverTake(double timeDifference)
    {
        this.TotalTime -= timeDifference;
    }

    public void LosePosition(double timeDifference)
    {
        this.TotalTime += timeDifference;
    }

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
        this.Status = "Racing";
    }

    public void Refuel(double fuelAmount)
    {
        this.TotalTime += 20.0d;
        this.Car.Refuel(fuelAmount);
    }

    public void ChangeTyre(List<string> arguments)
    {
        this.TotalTime += 20.0d;
        this.Car.ChangeTyre(arguments);
    }

    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        protected set { fuelConsumptionPerKm = value; }
    }
    
    public Car Car
    {
        get { return car; }
        protected set { car = value; }
    }
    
    public double TotalTime
    {
        get { return totalTime; }
        protected set { totalTime = value; }
    }
    
    public string Name
    {
        get { return this.name; }
        protected set
        {
            this.name = value;
        }
    }
    
}
