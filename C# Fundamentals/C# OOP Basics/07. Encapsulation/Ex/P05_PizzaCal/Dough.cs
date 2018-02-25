using System;

public class Dough
{	private const double whiteFlour = 1.5;
    private const double wholegrainFlour = 1.0;

    private const double crispyBaking = 0.9;
    private const double chewyBaking = 1.1;
    private const double homemadeBaking = 1.0;

    private string flourType;
    private string bakingTechnique;
    private double weight;
    private double totalCalories => this.GetTotalDoughCal();

    public Dough(string flourType, string bakingTecnhique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTecnhique;
        this.Weight = weight;
    }
    
    public double TotalCalories
    {
        get
        {
            return totalCalories;
        }
    }

    private double GetTotalDoughCal()
    {
        double flourModifier = 0;
        switch (this.FlourType.ToLower())
        {
            case "white":
                flourModifier = whiteFlour;
                break;
            case "wholegrain":
                flourModifier = wholegrainFlour;
                break;
            default:
                break;
        }

        double bakingModifier = 0;

        switch (this.BakingTechnique.ToLower())
        {
            case "chewy":
                bakingModifier = chewyBaking;
                break;
            case "crispy":
                bakingModifier = crispyBaking;
                break;
            case "homemade":
                bakingModifier = homemadeBaking;
                break;
            default:
                break;
        }

        double result = (2 * this.Weight) * flourModifier * bakingModifier;
        
        return result;
    }

    private double Weight
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

    private string BakingTechnique
    {
        get
        {
            return this.bakingTechnique;
        }
        set
        {
            string currBakeLow = value.ToLower();
            if (currBakeLow != "crispy" && currBakeLow != "chewy" && currBakeLow != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.bakingTechnique = value;
        }
    }

    private string FlourType
    {
        get
        {
            return this.flourType;
        }
        set
        {
            string currFlourLow = value.ToLower();
            if (currFlourLow != "white" && currFlourLow != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.flourType = value;
        }
    }

}
