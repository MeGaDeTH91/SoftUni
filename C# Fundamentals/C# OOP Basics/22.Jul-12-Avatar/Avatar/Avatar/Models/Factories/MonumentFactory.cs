using System;
using System.Collections.Generic;

public class MonumentFactory
{
    public Monument AssignMonument(List<string> arguments)
    {
        string type = arguments[0];
        string name = arguments[1];
        int affinity = int.Parse(arguments[2]);

        switch (type)
        {
            case "Air":
                return new AirMonument(name, affinity);
            case "Fire":
                return new FireMonument(name, affinity);
            case "Earth":
                return new EarthMonument(name, affinity);
            case "Water":
                return new WaterMonument(name, affinity);
            default:
                throw new ArgumentException();
        }
    }
}
