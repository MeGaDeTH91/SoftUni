package t_05_generic_count;

public class Box<E extends Comparable<E>> {
    private E value;

    public Box(E value) {
        this.value = value;
    }

    public void setValue(E value) {
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
