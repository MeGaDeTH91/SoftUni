package t_03_wild_farm.foods;

public abstract class Food {
    private final int quantity;

    public Food(int quantity) {
        this.quantity = quantity;
    }

    public int getQuantity() {
        return quantity;
    }
}
