using System;

public abstract class Feline : Mammal
{
    protected const double CatWeightIncreasePerFoodPiece = 0.30d;
    protected const double TigerWeightIncreasePerFoodPiece = 1.0d;

    public Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
    {
        this.Breed = breed;
    }

    public string Breed { get; set; }

    public override string ToString()
    {
        return $"{this.GetType()} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
