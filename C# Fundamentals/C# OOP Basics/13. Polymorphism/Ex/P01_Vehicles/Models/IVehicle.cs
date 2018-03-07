public interface IVehicle
{
    double FuelConsumptionPerKm { get; set; }
    double FuelQuantity { get; set; }
    double FuelTankCapacity { get; set; }

    string Drive(double kilometres);
    string DriveEmpty(double kilometres);
    void Refuel(double liters);
}