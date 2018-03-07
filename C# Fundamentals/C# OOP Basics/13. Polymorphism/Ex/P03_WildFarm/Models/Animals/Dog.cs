using System;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    public override void FeedAnimal(string foodType, int foodQuantity)
    {
        if (foodType == "Meat")
        {
            this.Weight += foodQuantity * DogWeightIncreasePerFoodPiece;
            this.FoodEaten += foodQuantity;
        }
        else
        {
            Console.WriteLine(string.Format(AnimalDoesNotEatThisFoodError, this.GetType(), foodType));
        }
    }

    public override string ProduceSound()
    {
        return "Woof!";
    }
}
