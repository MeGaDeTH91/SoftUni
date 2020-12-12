package t_05_restaurant.restaurant;

import java.math.BigDecimal;

public class Coffee extends HotBeverage{
    private static final double COFFEE_MILLILITERS = 50.0;
    private static final BigDecimal COFFEE_PRICE = BigDecimal.valueOf(3.50);
    private final double caffeine;

    public Coffee(String name, double caffeine) {
        super(name, COFFEE_PRICE, COFFEE_MILLILITERS);
        this.caffeine = caffeine;
    }

    public double getCaffeine() {
        return caffeine;
    }
}
