using System;
using System.Collections.Generic;
using System.Linq;

public class DriverFactory
{
    TyreFactory tyreFactory = new TyreFactory();

    public Driver RegisterDriver(List<string> commandArgs)
    {
        string type = commandArgs[0];
        string name = commandArgs[1];
        int carHp = int.Parse(commandArgs[2]);
        double carFuelAmount = double.Parse(commandArgs[3]);
        
        Tyre tyre = this.tyreFactory.AddTyre(commandArgs.Skip(4).ToList());
        
        Car car = new Car(carHp, carFuelAmount, tyre);

        if(type == "Aggressive")
        {
            return new AggressiveDriver(name, car);
        }
        else if(type == "Endurance")
        {
            return new EnduranceDriver(name, car);
        }
        else
        {
            throw new ArgumentException();
        }
    }
}
