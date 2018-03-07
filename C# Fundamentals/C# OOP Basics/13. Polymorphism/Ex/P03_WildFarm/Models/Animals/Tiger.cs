using System;

public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    public override void FeedAnimal(string foodType, int foodQuantity)
    {
        if (foodType == "Meat")
        {
            this.Weight += foodQuantity * TigerWeightIncreasePerFoodPiece;
            this.FoodEaten += foodQuantity;
        }
        else
        {
            Console.WriteLine(string.Format(AnimalDoesNotEatThisFoodError, this.GetType(), foodType));
        }
    }

    public override string ProduceSound()
    {
        return "ROAR!!!";
    }
}
