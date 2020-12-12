package t_06_generic_count_double;

public class Box<E extends Comparable<E>> {
    private final E value;

    public Box(E value) {
        this.value = value;
    }

    public boolean isGreater(E checkValue) {
        return value.compareTo(checkValue) > 0;
    }

    @Override
    public String toString() {
        return String.format("%s: %s", value.getClass().getName(), value.toString());
    }
}
