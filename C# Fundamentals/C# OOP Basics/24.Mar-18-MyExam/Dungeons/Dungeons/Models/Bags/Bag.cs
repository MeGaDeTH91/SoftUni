using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public abstract class Bag
{
    private const int Initial_Bag_Capacity = 100;

    private int capacity;
    private List<Item> items;

    public IReadOnlyCollection<Item> Items { get { return this.items.AsReadOnly(); } }

    private void Add(Item item)
    {
        items.Add(item);
    }

    public int Load => this.Items.Sum(x => x.Weight);

    protected Bag(int capacity = Initial_Bag_Capacity)
    {
        this.Capacity = capacity;
        this.items = new List<Item>();
    }
    

    public void AddItem(Item item)
    {
        if(this.Load + item.Weight > this.Capacity)
        {
            throw new InvalidOperationException("Bag is full!");
        }
        this.items.Add(item);
    }
    public Item GetItem(string name)
    {
        if(this.Items.Count < 1)
        {
            throw new InvalidOperationException("Bag is empty!");
        }

        var item = this.Items.FirstOrDefault(x => x.GetType().Name == name);
        if(item == null)
        {
            throw new ArgumentException($"No item with name {name} in bag!");
        }

        this.items.Remove(item);
        return item;
    }

    public int Capacity
    {
        get
        {
            return this.capacity;
        }
        protected set
        {
            this.capacity = value;
        }
    }
}
