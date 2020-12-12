package t_04_pizza_calories;

import java.util.ArrayList;
import java.util.List;

public class Pizza {
    private String name;
    private Dough dough;
    private final List<Topping> toppings;
    private int numberOfToppings;

    public Pizza(String name, int numberOfToppings) {
        this.setName(name);
        this.setToppings(numberOfToppings);
        toppings = new ArrayList<>();
    }

    public void addTopping(Topping topping) {
        if (toppings.size() >= numberOfToppings) {
            throw new IllegalArgumentException("Number of toppings should be in range [0..10].");
        }
        toppings.add(topping);
    }

    public double getOverallCalories() {
        return this.dough.calculateCalories() + this.toppings.stream().mapToDouble(Topping::calculateCalories).sum();
    }

    public void setDough(Dough dough) {
        this.dough = dough;
    }

    private void setName(String name) {
        if (name == null || name.trim().isEmpty() || name.length() > 15) {
            throw new IllegalArgumentException("t_04_pizza_calories.Pizza name should be between 1 and 15 symbols.");
        }
        this.name = name;
    }

    private void setToppings(int numberOfToppings) {
        if (numberOfToppings < 0 || numberOfToppings > 10) {
            throw new IllegalArgumentException("Number of toppings should be in range [0..10].");
        }
        this.numberOfToppings = numberOfToppings;
    }
}
