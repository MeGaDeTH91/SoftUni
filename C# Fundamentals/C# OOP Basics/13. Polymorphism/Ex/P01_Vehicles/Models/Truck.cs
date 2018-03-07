using System;

public class Truck : Vehicle
{
    public Truck(double fuelQuant, double fuelConsum, double tankCapacity) : base(fuelQuant, fuelConsum, tankCapacity)
    {
        this.FuelConsumptionPerKm = fuelConsum + TruckConsumptionIncrease;
    }

    public override void Refuel(double liters)
    {
        if (liters <= 0)
        {
            throw new InvalidOperationException(FuelMustBePositiveMessage);
        }
        if (this.FuelQuantity + liters > this.FuelTankCapacity)
        {
            throw new InvalidOperationException(string.Format(FuelIsMoreThanCapacityMessage, liters));
        }
        else
        {
            this.FuelQuantity += TruckFuelLeak * liters;
        }
        
    }
}
