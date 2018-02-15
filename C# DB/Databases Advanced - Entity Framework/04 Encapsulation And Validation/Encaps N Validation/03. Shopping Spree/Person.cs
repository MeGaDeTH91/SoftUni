using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> productBag;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.productBag = new List<Product>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }

    public decimal Money
    {
        get
        {
            return this.money;
        }
        private set
        {
            if(value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }

    public string AddToBag(Product product)
    {
        if(this.Money < product.Price)
        {
            return $"{this.Name} can't afford {product.Name}";
        }

        this.Money -= product.Price;
        this.productBag.Add(product);
        return $"{this.Name} bought {product.Name}";
    }

    public override string ToString()
    {
        if(this.productBag.Count == 0)
        {
            return $"{this.Name} - Nothing bought";
        }

        return $"{this.Name} - {string.Join(", ", productBag.Select(x => x.Name))}";
    }
}