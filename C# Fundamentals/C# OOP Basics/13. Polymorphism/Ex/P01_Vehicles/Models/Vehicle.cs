using System;

public abstract class Vehicle : IVehicle
{
    protected const double CarConsumptionIncrease = 0.9d;
    protected const double TruckConsumptionIncrease = 1.6d;
    protected const double BusConsumptionIncrease = 1.4d;
    protected const double TruckFuelLeak = 0.95d;

    protected const string FuelMustBePositiveMessage = "Fuel must be a positive number";
    protected const string FuelIsMoreThanCapacityMessage = "Cannot fit {0} fuel in the tank";

    public double FuelQuantity { get; set; }
    public double FuelConsumptionPerKm { get; set; }
    public double FuelTankCapacity { get; set; }

    public virtual string DriveEmpty(double kilometres) { return string.Empty; }
    public virtual void Refuel(double liters)
    {
        if (liters <= 0)
        {
            throw new InvalidOperationException(FuelMustBePositiveMessage);
        }
        if (this.FuelQuantity + liters > this.FuelTankCapacity)
        {
            throw new InvalidOperationException(string.Format(FuelIsMoreThanCapacityMessage, liters));
        }
        this.FuelQuantity += liters;
    }

    public Vehicle(double fuelQuant, double fuelConsum, double tankCapacity)
    {
        this.FuelQuantity = fuelQuant;
        this.FuelConsumptionPerKm = fuelConsum;
        this.FuelTankCapacity = tankCapacity;
        if (this.FuelQuantity > this.FuelTankCapacity)
        {
            this.FuelQuantity = 0;
        }
    }

    public virtual string Drive(double kilometres)
    {
        if(this.FuelQuantity <= this.FuelTankCapacity)
        {
            double neededFuel = kilometres * this.FuelConsumptionPerKm;
            if (this.FuelQuantity >= neededFuel)
            {
                this.FuelQuantity -= neededFuel;
                return $"{this.GetType()} travelled {kilometres} km";
            }
            else
            {
                return $"{this.GetType()} needs refueling";
            }
        }
        else
        {
            return string.Empty;
        }
    }
    public override string ToString()
    {
        return $"{this.GetType()}: {this.FuelQuantity:F2}";
    }
}
