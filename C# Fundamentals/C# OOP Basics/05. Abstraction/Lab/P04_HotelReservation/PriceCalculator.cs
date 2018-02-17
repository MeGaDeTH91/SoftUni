using System;
using System.Collections.Generic;
using System.Text;

public class PriceCalculator
{
    public decimal CalculateThisPriceAnimal(decimal pricePerDay, int dayNumber, Season season, DiscountType currDiscountType)
    {
        decimal result = 0.0m;
        int seasongMultiplier = (int)season + 1;
        pricePerDay *= seasongMultiplier;
        result = pricePerDay * dayNumber;
        decimal discountPercent = (decimal)currDiscountType/10m;
        decimal currDiscount = result * discountPercent;
        result -= currDiscount;
        return result;
    }
}
