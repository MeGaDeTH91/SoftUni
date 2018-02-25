using System;
using System.Collections.Generic;
using System.Text;

public class Topping
{
    private const double meatTopp = 1.2;
    private const double veggiesTopp = 0.8;
    private const double cheeseTopp = 1.1;
    private const double sauceTopp = 0.9;

    private string type;
    private double weight;
    private double totalCalories => this.GetToppingCal();

    public double TotalCalories
    {
        get
        {
            return this.totalCalories;
        }
    }

    private double GetToppingCal()
    {
        double toppingModifier = 0;

        switch (this.Type.ToLower())
        {
            case "meat":
                toppingModifier = meatTopp;
                break;
            case "veggies":
                toppingModifier = veggiesTopp;
                break;
            case "cheese":
                toppingModifier = cheeseTopp;
                break;
            case "sauce":
                toppingModifier = sauceTopp;
                break;
            default:
                break;
        }
        
        double result = (2 * this.Weight) * toppingModifier;
        return result;
    }

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    private string Type
    {
        get
        {
            return this.type;
        }
        set
        {
            string currLow = value.ToLower();
            if(currLow != "meat" && currLow != "veggies" &&
               currLow != "cheese" && currLow != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            this.type = value;
        }
    }
    private double Weight
    {
        get
        {
            return this.weight;
        }
        set
        {
            if(value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
            }
            this.weight = value;
        }
    }
}
