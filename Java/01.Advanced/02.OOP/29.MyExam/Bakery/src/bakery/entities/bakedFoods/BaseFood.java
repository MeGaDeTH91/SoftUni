package bakery.entities.bakedFoods;

import bakery.entities.bakedFoods.interfaces.BakedFood;

import static bakery.common.ExceptionMessages.INVALID_NAME;
import static bakery.common.ExceptionMessages.INVALID_PORTION;
import static bakery.common.ExceptionMessages.INVALID_PRICE;

public abstract class BaseFood implements BakedFood {

    private String name;
    private double portion;
    private double price;

    protected BaseFood(String name, double portion, double price) {
        this.setName(name);
        this.setPortion(portion);
        this.setPrice(price);
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public double getPortion() {
        return portion;
    }

    @Override
    public double getPrice() {
        return price;
    }

    public void setName(String name) {
        if (name == null || name.trim().isEmpty()) {
            throw new IllegalArgumentException(INVALID_NAME);
        }
        this.name = name;
    }

    public void setPortion(double portion) {
        if (portion <= 0) {
            throw new IllegalArgumentException(INVALID_PORTION);
        }
        this.portion = portion;
    }

    public void setPrice(double price) {
        if (price <= 0) {
            throw new IllegalArgumentException(INVALID_PRICE);
        }
        this.price = price;
    }

    @Override
    public String toString() {
        return String.format("%s: %.2fg - %.2f", getName(), getPortion(), getPrice());
    }
}
