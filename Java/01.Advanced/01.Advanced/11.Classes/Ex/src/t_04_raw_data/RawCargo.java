package t_04_raw_data;

public class RawCargo {
    private final String type;
    private final int weight;

    public RawCargo(String type, int weight) {
        this.type = type;
        this.weight = weight;
    }

    public String getType() {
        return type;
    }
}
