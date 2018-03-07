using System;

public class Bus : Vehicle
{
    public Bus(double fuelQuant, double fuelConsum, double tankCapacity) : base(fuelQuant, fuelConsum, tankCapacity)
    {

    }

    public override string Drive(double kilometres)
    {
        if (this.FuelQuantity <= this.FuelTankCapacity)
        {
            double neededFuel = kilometres * (this.FuelConsumptionPerKm + BusConsumptionIncrease);
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

    public override string DriveEmpty(double kilometres)
    {
        return base.Drive(kilometres);
    }
}
