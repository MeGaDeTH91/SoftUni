using System;
using System.Linq;

public class P04_HotelReservation
{
    public static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        decimal pricePerDay = decimal.Parse(tokens[0]);
        int numberOfDays = int.Parse(tokens[1]);
        Season season = Enum.Parse<Season>(tokens[2]);
        bool thereIsDiscount = tokens.Length == 4;
        DiscountType discount = thereIsDiscount ? Enum.Parse<DiscountType>(tokens[3]):DiscountType.None;

        PriceCalculator newCalculator = new PriceCalculator();
        decimal price = newCalculator.CalculateThisPriceAnimal(pricePerDay, numberOfDays, season, discount);
        Console.WriteLine($"{price:F2}");
    }
}
