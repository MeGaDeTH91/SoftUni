using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Topping
{
    private decimal tkModifier;
    private const decimal BaseCaloriesPerGram = 2.0m;

    private string toppingType;
    private decimal toppWeight;

    public Topping(string toppingType, decimal toppWeight)
    {
        this.ToppingType = toppingType;
        this.ToppWeight = toppWeight;
    }

    public string ToppingType
    {
        get
        {
            return this.toppingType;
        }
        set
        {
            if(value.ToLower() != "meat" && value.ToLower() != "veggies" &&
               value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            switch (value.ToLower())
            {
                case "meat":
                    tkModifier = 1.2m;
                    break;
                case "veggies":
                    tkModifier = 0.8m;
                    break;
                case "cheese":
                    tkModifier = 1.1m;
                    break;
                case "sauce":
                    tkModifier = 0.9m;
                    break;
                default:
                    break;
            }
            this.toppingType = value;
        }
    }

    public decimal ToppWeight
    {
        get
        {
            return this.toppWeight;
        }
        set
        {
            if(value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
            }
            this.toppWeight = value;
        }
    }

    public decimal Calories()
    {
        return BaseCaloriesPerGram * tkModifier * this.ToppWeight;
    }
}