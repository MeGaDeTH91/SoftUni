package onlineShop.models.products.components;

import onlineShop.models.products.BaseProduct;

public abstract class BaseComponent extends BaseProduct implements Component{

    private int generation;

    protected BaseComponent(int id, String manufacturer, String model, double price, double overallPerformance, int generation) {
        super(id, manufacturer, model, price, overallPerformance);
        this.setGeneration(generation);
    }

    @Override
    public int getGeneration() {
        return generation;
    }

    private void setGeneration(int generation) {
        if (generation <= 0) {
            throw new IllegalArgumentException("Generation can not be less or equal than 0.");
        }

        this.generation = generation;
    }

    @Override
    public String toString() {
        return super.toString() + String.format(" Generation: %d", getGeneration());
    }
}
