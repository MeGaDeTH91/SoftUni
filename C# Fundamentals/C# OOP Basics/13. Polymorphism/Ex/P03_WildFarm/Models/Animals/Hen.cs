using System;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingsize) : base(name, weight, wingsize)
    {
    }

    public override void FeedAnimal(string foodType, int foodQuantity)
    {
        this.Weight += foodQuantity * HenWeightIncreasePerFoodPiece;
        this.FoodEaten += foodQuantity;
    }

    public override string ProduceSound()
    {
        return "Cluck";
    }
}