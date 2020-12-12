package t_05_car_salesman;

public class Engine {
    private final String model;
    private final long power;
    private final long displacement;
    private final String efficiency;
    private final static String NON_EXISTING = "n/a";

    public Engine(String model, long power) {
        this(model, power, -100, NON_EXISTING);
    }

    public Engine(String model, long power, long displacement) {
        this(model, power, displacement, NON_EXISTING);
    }

    public Engine(String model, long power, String efficiency) {
        this(model, power, -100, efficiency);
    }

    public Engine(String model, long power, long displacement, String efficiency) {
        this.model = model;
        this.power = power;
        this.displacement = displacement;
        this.efficiency = efficiency;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder(21);

        sb.append(this.model);
        sb.append(":\n");

        sb.append("    Power: ");
        sb.append(this.power);
        sb.append("\n");

        sb.append("    Displacement: ");
        sb.append(this.displacement == -100 ? NON_EXISTING : this.displacement);
        sb.append("\n");

        sb.append("    Efficiency: ");
        sb.append(this.efficiency != null ? this.efficiency : NON_EXISTING);
        sb.append("\n");

        return sb.toString();
    }
}
