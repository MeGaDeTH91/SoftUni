using System;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    public override void FeedAnimal(string foodType, int foodQuantity)
    {
        if (foodType == "Vegetable" || foodType == "Fruit")
        {
            this.Weight += foodQuantity * MouseWeightIncreasePerFoodPiece;
            this.FoodEaten += foodQuantity;
        }
        else
        {
            Console.WriteLine(string.Format(AnimalDoesNotEatThisFoodError, this.GetType(), foodType));
        }
    }

    public override string ProduceSound()
    {
        return "Squeak";
    }
}
