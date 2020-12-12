package t_03_wild_farm.animals;

import t_03_wild_farm.foods.Food;

import java.text.DecimalFormat;

public class Cat extends Felime {
    private final String breed;

    public Cat(String animalName, String animalType, double animalWeight, String livingRegion, String breed) {
        super(animalName, animalType, animalWeight, livingRegion);
        this.breed = breed;
    }

    @Override
    public void makeSound() {
        System.out.println("Meowwww");
    }

    @Override
    public void eat(Food food) {
        this.setFoodEaten(this.getFoodEaten() + food.getQuantity());
    }

    @Override
    public String toString() {
        DecimalFormat df = new DecimalFormat("0.##");

        return String.format("%s[%s, %s, %s, %s, %d]", this.getAnimalType(), this.getAnimalName(), this.breed,
                df.format(this.getAnimalWeight()), this.getLivingRegion(), this.getFoodEaten());
    }
}
