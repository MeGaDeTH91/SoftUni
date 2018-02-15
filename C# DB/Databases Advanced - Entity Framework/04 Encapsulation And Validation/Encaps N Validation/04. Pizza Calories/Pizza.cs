using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza(string name, List<Topping> toppings)
    {
        this.Name = name;
        this.Toppings = toppings;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if(string.IsNullOrEmpty(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }

    public Dough Dough
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

    public List<Topping> Toppings
    {
        get
        {
            return this.toppings;
        }
        set
        {
            if(value.Count > 10)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..10].");
            }
            this.toppings = new List<Topping>(value);
        }
    }

    public void AddTopping(Topping topping)
    {
        if (this.toppings.Count == 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }

        this.toppings.Add(topping);
    }

    public override string ToString()
    {
        decimal totalCal = 0.0m;
        totalCal = this.Dough.Calories() + this.Toppings.Sum(x => x.Calories());

        return $"{this.Name} - {totalCal:F2} Calories.";
    }
}

