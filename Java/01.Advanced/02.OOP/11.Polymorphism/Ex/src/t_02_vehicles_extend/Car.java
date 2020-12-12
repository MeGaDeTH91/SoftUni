package t_02_vehicles_extend;

public class Car extends Vehicle {
    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) {
        super(fuelQuantity, fuelConsumption, tankCapacity);
        this.setAddedFuelConsumption(0.9);
    }
}
