using System;

public abstract class Bird : Animal
{
    protected const double HenWeightIncreasePerFoodPiece = 0.35d;
    protected const double OwlWeightIncreasePerFoodPiece = 0.25d;

    public Bird(string name, double weight, double wingsize) : base(name, weight)
    {
        this.WingSize = wingsize;
    }

    public double WingSize { get; set; }
    public override string ToString()
    {
        return $"{this.GetType()} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}
