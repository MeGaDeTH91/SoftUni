package t_01_vehicles;

public class Car extends Vehicle{
    public Car(double fuelQuantity, double fuelConsumption) {
        super(fuelQuantity, fuelConsumption);
        this.setFuelConsumption(fuelConsumption + 0.9);
    }

    @Override
    public void refuel(double fuel) {
        this.setFuelQuantity(this.getFuelQuantity() + fuel);
    }
}
