package t_10_tuple;

public class Tuple<K, V> {
    private K item1;
    private V item2;

    public Tuple(K item1, V item2) {
        this.item1 = item1;
        this.item2 = item2;
    }

    @Override
    public String toString() {
        return String.format("%s -> %s", item1.toString(), item2.toString());
    }
}
