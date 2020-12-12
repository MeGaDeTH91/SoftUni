package t_04_need_for_speed.vehicle;

public class SportCar extends Car{
    public SportCar(double fuel, int horsePower) {
        super(fuel, horsePower);
        super.setFuelConsumption(10);
    }
}
