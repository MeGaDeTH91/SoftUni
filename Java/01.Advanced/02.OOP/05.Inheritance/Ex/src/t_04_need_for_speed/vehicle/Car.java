package t_04_need_for_speed.vehicle;

public class Car extends Vehicle{
    public Car(double fuel, int horsePower) {
        super(fuel, horsePower);
        super.setFuelConsumption(3);
    }
}
