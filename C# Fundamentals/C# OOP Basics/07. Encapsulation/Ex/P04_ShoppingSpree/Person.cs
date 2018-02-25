using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bag;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.bag = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        this.bag.Add(product);
    }

    public List<Product> Bag
    {
        get
        {
            return this.bag;
        }
    }
    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
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
        set
        {
            if(value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }
}
