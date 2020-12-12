package t_03_speed_racing;

public class CarClass {
    private final String model;
    private double fuel;
    private final double consumption;
    private double distanceTraveled;

    public CarClass(String model, double fuel, double consumption) {
        this.model = model;
        this.fuel = fuel;
        this.consumption = consumption;
        this.distanceTraveled = 0;
    }

    public boolean drive(double distance) {
        double fuelNeeded = consumption * distance;
        if (fuel - fuelNeeded >= 0) {
            fuel -= fuelNeeded;
            distanceTraveled += distance;

            return true;
        }

        return false;
    }

    @Override
    public String toString() {
        return String.format("%s %.2f %.0f", model, fuel, distanceTraveled);
    }
}
