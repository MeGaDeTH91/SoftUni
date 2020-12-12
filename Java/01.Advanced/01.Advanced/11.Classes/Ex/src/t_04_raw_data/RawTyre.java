package t_04_raw_data;

public class RawTyre {
    private double pressure;
    private int age;

    public RawTyre(double pressure, int age) {
        this.pressure = pressure;
        this.age = age;
    }

    public double getPressure() {
        return pressure;
    }
}
