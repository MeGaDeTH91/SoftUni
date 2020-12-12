package t_03_wild_farm.animals;

import t_03_wild_farm.foods.Food;

public class Tiger extends Felime{
    public Tiger(String animalName, String animalType, double animalWeight, String livingRegion) {
        super(animalName, animalType, animalWeight, livingRegion);
    }

    @Override
    public void makeSound() {
        System.out.println("ROAAR!!!");
    }

    @Override
    public void eat(Food food) {
        String foodType = food.getClass().getSimpleName();

        if (foodType.equals("Meat")) {
            this.setFoodEaten(this.getFoodEaten() + food.getQuantity());
        } else {
            System.out.println("Tigers are not eating that type of food!");
        }
    }
}
