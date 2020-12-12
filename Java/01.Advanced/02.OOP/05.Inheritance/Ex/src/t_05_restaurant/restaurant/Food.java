package t_05_restaurant.restaurant;

import java.math.BigDecimal;

public class Food extends Product{
    private final double grams;

    public Food(String name, BigDecimal price, double grams) {
        super(name, price);
        this.grams = grams;
    }

    public double getGrams() {
        return grams;
    }
}
