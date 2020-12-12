package t_04_need_for_speed.vehicle;

public class RaceMotorcycle extends Motorcycle{
    public RaceMotorcycle(double fuel, int horsePower) {
        super(fuel, horsePower);
        super.setFuelConsumption(8);
    }
}
