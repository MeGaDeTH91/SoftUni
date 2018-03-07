using System;

public abstract class Mammal : Animal
{
    protected const double MouseWeightIncreasePerFoodPiece = 0.10d;
    protected const double DogWeightIncreasePerFoodPiece = 0.40d;

    public Mammal(string name, double weight, string livingRegion) : base(name, weight)
    {
        this.LivingRegion = livingRegion;
    }

    public string LivingRegion { get; set; }

    public override string ToString()
    {
        return $"{this.GetType()} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
