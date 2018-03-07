using System;

public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    public override void FeedAnimal(string foodType, int foodQuantity)
    {
        if(foodType == "Vegetable" || foodType == "Meat")
        {
            this.Weight += foodQuantity * CatWeightIncreasePerFoodPiece;
            this.FoodEaten += foodQuantity;
        }
        else
        {
            Console.WriteLine(string.Format(AnimalDoesNotEatThisFoodError, this.GetType(), foodType));
        }
    }

    public override string ProduceSound()
    {
        return "Meow";
    }
}
