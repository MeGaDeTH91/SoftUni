using System;
using System.Collections.Generic;

public class BenderFactory
{
    public Bender AssignBender(List<string> arguments)
    {
        string type = arguments[0];
        string name = arguments[1];
        int power = int.Parse(arguments[2]);
        double secondaryParameter = double.Parse(arguments[3]);

        switch (type)
        {
            case "Air":
                return new AirBender(name, power, secondaryParameter);
            case "Fire":
                return new FireBender(name, power, secondaryParameter);
            case "Earth":
                return new EarthBender(name, power, secondaryParameter);
            case "Water":
                return new WaterBender(name, power, secondaryParameter);
            default:
                throw new ArgumentException();
        }
    }
}
