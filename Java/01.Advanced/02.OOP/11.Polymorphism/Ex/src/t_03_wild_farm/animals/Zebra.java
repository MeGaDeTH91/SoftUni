package t_03_wild_farm.animals;

import t_03_wild_farm.foods.Food;

public class Zebra extends Mammal{
    public Zebra(String animalName, String animalType, double animalWeight, String livingRegion) {
        super(animalName, animalType, animalWeight, livingRegion);
    }

    @Override
    public void makeSound() {
        System.out.println("Zs");
    }

    @Override
    public void eat(Food food) {
        String foodType = food.getClass().getSimpleName();

        if (foodType.equals("Vegetable")) {
            this.setFoodEaten(this.getFoodEaten() + food.getQuantity());
        } else {
            System.out.println("Zebras are not eating that type of food!");
        }
    }
}
