using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;
    private int toppingCount => this.Toppings.Count;
    private double totalCalories => this.Toppings.Sum(x => x.TotalCalories) + this.Dough.TotalCalories;

    public int ToppingCount
    {
        get { return this.toppingCount; }
    }
    public double TotalCalories
    {
        get
        {
            return this.totalCalories;
        }
    }

    public Pizza(string name)
    {
        this.Name = name;
    }

    public Pizza(string name, Dough dough, List<Topping> toppings)
    {
        this.Name = name;
        this.Dough = dough;
        this.Toppings = new List<Topping>(toppings);
    }

    private string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if(string.IsNullOrWhiteSpace(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }
    private Dough Dough
    {
        get
        {
            return this.dough;
        }
        set
        {
            this.dough = value;
        }
    }
    private List<Topping> Toppings
    {
        get
        {
            return this.toppings;
        }
        set
        {
            if(value.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings = value;
        }
    }
}
