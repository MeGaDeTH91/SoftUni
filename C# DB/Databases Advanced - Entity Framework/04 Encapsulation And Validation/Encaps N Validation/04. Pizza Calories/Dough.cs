using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Dough
{
    private const decimal BaseCaloriesPerGram = 2.0m;
    private decimal ftModifier;
    private decimal bkModifier;


    private string flourType;
    private string bakingTechnique;
    private decimal weight;

    public Dough(string flourType, string bakingTechnique, decimal weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public string FlourType
    {
        get
        {
            return this.flourType;
        }
        set
        {
            if(value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            switch (value.ToLower())
            {
                case "white" :ftModifier = 1.5m;
                    break;
                case "wholegrain": ftModifier = 1.0m;
                    break;
                default:
                    break;
            }
            this.flourType = value;
        }
    }

    public string BakingTechnique
    {
        get
        {
            return this.bakingTechnique;
        }
        set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && 
                value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            switch (value.ToLower())
            {
                case "crispy":
                    bkModifier = 0.9m;
                    break;
                case "chewy":
                    bkModifier = 1.1m;
                    break;
                case "homemade":
                    bkModifier = 1.0m;
                    break;
                default:
                    break;
            }
            this.bakingTechnique = value;
        }
    }

    public decimal Weight
    {
        get
        {
            return this.weight;
        }
        set
        {
            if(value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }

    public decimal Calories()
    {
        return BaseCaloriesPerGram * ftModifier * bkModifier * this.Weight;
    }
}