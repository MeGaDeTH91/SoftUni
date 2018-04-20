using System;

public class Constants
{
    public const double InitialOreQuantity = 0.0d;
    public const double InitialEnergyQuantity = 0.0d;

    //Machine Type
    public const string SuccessfullRegistration = "Successfully registered {0}";
    
    public const string OreOutputToday = "Produced {0} ore today!";

    public const string EnergyOutputToday = "Produced {0} energy today!";

    //New Mode
    public const string ModeChangeMessage = "Mode changed to {0}!";

    //Value
    public const string ProvidersRepaired = "Providers are repaired by {0}";

    //Id
    public const string InspectNoSuchEntity = "No entity found with id - {0}";

    //Full Entity Type, 
    public const string InspectEntityFullName = "{0}";
    //Entity Durability, 
    public const string InspectEntityDurability = "Durability: {0}";

    //On ShutDown
    public const string SystemShutDownMessage = "System Shutdown";
    public const string SystemShutDownTotalEnergy = "Total Energy Produced: {0}";
    public const string SystemShutDownTotalOre = "Total Mined Plumbus Ore: {0}";
}