using System;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingsize) : base(name, weight, wingsize)
    {
    }

    public override void FeedAnimal(string foodType, int foodQuantity)
    {
        if (foodType == "Meat")
        {
            this.Weight += foodQuantity * OwlWeightIncreasePerFoodPiece;
            this.FoodEaten += foodQuantity;
        }
        else
        {
            Console.WriteLine(string.Format(AnimalDoesNotEatThisFoodError, this.GetType(), foodType));
        }
    }

    public override string ProduceSound()
    {
        return "Hoot Hoot";
    }
}
