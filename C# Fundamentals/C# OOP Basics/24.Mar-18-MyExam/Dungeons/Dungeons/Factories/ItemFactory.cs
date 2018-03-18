using System;

public class ItemFactory
{
    public Item CreateItem(string itemType)
    {
        if(itemType.Equals("PoisonPotion"))
        {
            return new PoisonPotion();
        }
        else if (itemType.Equals("HealthPotion"))
        {
            return new HealthPotion();
        }
        else if (itemType.Equals("ArmorRepairKit"))
        {
            return new ArmorRepairKit();
        }
        else
        {
            throw new ArgumentException($"Invalid item \"{itemType}\"!");
        }
    }
}
