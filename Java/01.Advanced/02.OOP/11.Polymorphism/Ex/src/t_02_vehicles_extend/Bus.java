package t_02_vehicles_extend;

public class Bus extends Vehicle {
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) {
        super(fuelQuantity, fuelConsumption, tankCapacity);
        this.setAddedFuelConsumption(1.4);
    }
}
