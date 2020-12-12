package t_05_restaurant.restaurant;

import java.math.BigDecimal;

public class Salmon extends MainDish{
    private static final double SALMON_GRAMS = 22.0;

    public Salmon(String name, BigDecimal price) {
        super(name, price, SALMON_GRAMS);
    }
}
