using System;

public abstract class Animal
{
    protected const string AnimalDoesNotEatThisFoodError = "{0} does not eat {1}!";

    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public string Name { get; set; }
    public double Weight { get; set; }
    public int FoodEaten { get; set; }

    public abstract void FeedAnimal(string foodType, int foodQuantity);
    public abstract string ProduceSound();
}
