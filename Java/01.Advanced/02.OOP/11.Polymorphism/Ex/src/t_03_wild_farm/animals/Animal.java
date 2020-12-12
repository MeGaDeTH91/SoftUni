package t_03_wild_farm.animals;

import t_03_wild_farm.foods.Food;

public abstract class Animal {
    private final String animalName;
    private final String animalType;
    private final double animalWeight;
    private int foodEaten;

    public Animal(String animalName, String animalType, double animalWeight) {
        this.animalName = animalName;
        this.animalType = animalType;
        this.animalWeight = animalWeight;
    }

    public abstract void makeSound();
    public abstract void eat(Food food);

    protected String getAnimalName() {
        return animalName;
    }

    protected String getAnimalType() {
        return animalType;
    }

    protected double getAnimalWeight() {
        return animalWeight;
    }

    protected int getFoodEaten() {
        return foodEaten;
    }

    protected void setFoodEaten(int quantity) {
        if (quantity >= 0) {
            this.foodEaten += quantity;
        }
    }
}
