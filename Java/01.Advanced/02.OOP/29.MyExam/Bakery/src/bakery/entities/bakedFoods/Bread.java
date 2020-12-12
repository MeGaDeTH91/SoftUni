package bakery.entities.bakedFoods;

public class Bread extends BaseFood {

    private static final double InitialBreadPortion = 200.00;

    public Bread(String name, double price) {
        super(name, InitialBreadPortion, price);
    }
}
