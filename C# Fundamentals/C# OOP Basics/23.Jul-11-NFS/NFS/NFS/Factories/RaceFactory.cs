using System;

public class RaceFactory
{
    public Race OpenRace(string type, int length, string route, int prizePool)
    {
        switch (type)
        {
            case "Casual":
                return new CasualRace(length, route, prizePool);
            case "Drag":
                return new DragRace(length, route, prizePool);
            case "Drift":
                return new DriftRace(length, route, prizePool);
            default:
                throw new System.ArgumentOutOfRangeException(
                    nameof(type),
$"Race type must be “Casual”, “Drag”, “Drift”, “TimeLimit” or “Circuit”!");
        }
    }

    public Race OpenRace(string type, int length, string route, int prizePool, int extraparameter)
    {
        if (type == "Circuit")
        {
            return new CircuitRace(length, route, prizePool, extraparameter);
        }
        else if (type == "TimeLimit")
        {
            return new TimeLimitRace(length, route, prizePool, extraparameter);
        }
        else
        {
                throw new System.ArgumentOutOfRangeException(
                    nameof(type),
$"Car type must be “Performance” or “Show”!");
        }
    }
}
