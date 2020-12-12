package t_04_pizza_calories;

public class Topping {
    private String toppingType;
    private double weight;

    public Topping(String toppingType, double weight) {
        this.setToppingType(toppingType);
        this.setWeight(weight);
    }

    public double calculateCalories() {
        double totalCalories = weight * 2.0;

        switch (toppingType) {
            case "Meat":
                totalCalories *= 1.2;
                break;
            case "Veggies":
                totalCalories *= 0.8;
                break;
            case "Cheese":
                totalCalories *= 1.1;
                break;
            case "Sauce":
                totalCalories *= 0.9;
                break;
            default:
                break;
        }

        return totalCalories;
    }

    private void setToppingType(String toppingType) {
        if (toppingType == null || toppingType.trim().isEmpty() || (!toppingType.equals("Meat") && !toppingType.equals("Veggies")
                && !toppingType.equals("Cheese") && !toppingType.equals("Sauce"))) {
            throw new IllegalArgumentException(String.format("Cannot place %s on top of your pizza.", toppingType));
        }
        this.toppingType = toppingType;
    }

    private void setWeight(double weight) {
        if (weight < 1 || weight > 50) {
            throw new IllegalArgumentException(String.format("%s weight should be in the range [1..50].", toppingType));
        }
        this.weight = weight;
    }
}
