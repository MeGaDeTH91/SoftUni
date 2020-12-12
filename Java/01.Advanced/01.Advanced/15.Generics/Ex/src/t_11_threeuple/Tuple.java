package t_11_threeuple;

public class Tuple<K, V, M> {
    private K item1;
    private V item2;
    private M item3;

    public Tuple(K item1, V item2, M item3) {
        this.item1 = item1;
        this.item2 = item2;
        this.item3 = item3;
    }

    @Override
    public String toString() {
        return String.format("%s -> %s -> %s", item1.toString(), item2.toString(), item3.toString());
    }
}
