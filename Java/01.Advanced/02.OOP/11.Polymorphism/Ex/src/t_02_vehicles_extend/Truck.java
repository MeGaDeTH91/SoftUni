package t_02_vehicles_extend;

public class Truck extends Vehicle {
    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) {
        super(fuelQuantity, fuelConsumption, tankCapacity);
        this.setAddedFuelConsumption(1.6);
    }

    @Override
    public void refuel(double fuel) {
        super.refuel(fuel  * 0.95);
    }
}
