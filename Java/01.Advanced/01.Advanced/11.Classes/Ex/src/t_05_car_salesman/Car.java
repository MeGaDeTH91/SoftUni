package t_05_car_salesman;

public class Car {
    private final String model;
    private final Engine engine;
    private final long weight;
    private final String color;
    private final static String NON_EXISTING = "n/a";

    public Car(String model, Engine engine) {
        this(model, engine, -100, NON_EXISTING);
    }

    public Car(String model, Engine engine, long weight) {
        this(model, engine, weight, NON_EXISTING);
    }

    public Car(String model, Engine engine, String color) {
        this(model, engine, -100, color);
    }

    public Car(String model, Engine engine, long weight, String color) {
        this.model = model;
        this.engine = engine;
        this.weight = weight;
        this.color = color;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder(50);

        sb.append(this.model);
        sb.append(":\n");

        sb.append(this.engine.toString());

        sb.append("  Weight: ");
        sb.append(this.weight == -100 ? NON_EXISTING : this.weight);
        sb.append("\n");

        sb.append("  Color: ");
        sb.append(this.color != null ? this.color : NON_EXISTING);

        return sb.toString().trim();
    }
}
