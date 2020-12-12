package t_03_wild_farm.factories;

import t_03_wild_farm.foods.Food;
import t_03_wild_farm.foods.Meat;
import t_03_wild_farm.foods.Vegetable;

public class FoodFactory {
    public static Food createFood(String[] tokens) {
        String foodType = tokens[0];
        int foodQuantity = Integer.parseInt(tokens[1]);

        Food createdFood;

        switch (foodType) {
            case "Vegetable":
                createdFood = new Vegetable(foodQuantity);
                break;
            case "Meat":
                createdFood = new Meat(foodQuantity);
                break;
            default:
                throw new IllegalArgumentException("Invalid food type.");
        }

        return createdFood;
    }
}
