using System;
using System.Collections.Generic;

public class ProviderFactory
{
    public Provider RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        if(type == "Solar")
        {
            return new SolarProvider(id, energyOutput);
        }
        else if(type == "Pressure")
        {
            return new PressureProvider(id, energyOutput);
        }
        else
        {
            return null;
        }
    }
}
