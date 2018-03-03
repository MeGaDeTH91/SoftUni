using System;

public class Rebel : Person, IBuyer
{
    public Rebel(string name, int age, string group) : base(name, age, group)
    {
    }
    public void BuyFood()
    {
        this.Food += 5;
    }
}