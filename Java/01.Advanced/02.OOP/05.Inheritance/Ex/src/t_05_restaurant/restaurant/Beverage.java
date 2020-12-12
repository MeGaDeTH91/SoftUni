package t_05_restaurant.restaurant;

import java.math.BigDecimal;

public class Beverage extends Product{
    private final double milliliters;

    public Beverage(String name, BigDecimal price, double milliliters) {
        super(name, price);
        this.milliliters = milliliters;
    }

    public double getMilliliters() {
        return milliliters;
    }
}
