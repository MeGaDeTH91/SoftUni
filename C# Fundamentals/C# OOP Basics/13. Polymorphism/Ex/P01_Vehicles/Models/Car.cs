using System;

public class Car : Vehicle
{
    public Car(double fuelQuant, double fuelConsum, double tankCapacity) : base(fuelQuant, fuelConsum, tankCapacity)
    {
        this.FuelConsumptionPerKm = fuelConsum + CarConsumptionIncrease;
    }
}
