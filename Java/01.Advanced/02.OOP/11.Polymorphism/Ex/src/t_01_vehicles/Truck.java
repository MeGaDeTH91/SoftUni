package t_01_vehicles;

public class Truck extends Vehicle{
    public Truck(double fuelQuantity, double fuelConsumption) {
        super(fuelQuantity, fuelConsumption);
        this.setFuelConsumption(fuelConsumption + 1.6);
    }

    @Override
    public void refuel(double fuel) {
        this.setFuelQuantity(this.getFuelQuantity() + (fuel  * 0.95));
    }
}
