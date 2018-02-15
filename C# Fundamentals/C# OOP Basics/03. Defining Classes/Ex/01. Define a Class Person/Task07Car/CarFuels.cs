using System;
using System.Collections.Generic;
using System.Text;

public class CarFuels
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumptionPerKm { get; set; }
    public int DistanceTraveled { get; set; }

    public void Drive(int kilometres)
    {
        double neededFuel = kilometres * this.FuelConsumptionPerKm;
        if(this.FuelAmount - neededFuel >= 0)
        {
            this.FuelAmount -= neededFuel;
            this.DistanceTraveled += kilometres;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
