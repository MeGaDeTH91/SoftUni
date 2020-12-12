package t_02_integer_box;

public class Box<E> {
    private E value;

    public void setValue(E value) {
        this.value = value;
    }

    @Override
    public String toString() {
        return String.format("%s: %s", value.getClass().getName(), value.toString());
    }
}
