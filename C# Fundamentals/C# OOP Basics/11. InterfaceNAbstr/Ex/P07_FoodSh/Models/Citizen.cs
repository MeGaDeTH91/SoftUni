using System;

public class Citizen : Person, ICitizen, IBuyer
{
    public Citizen(string name, int age, string id, DateTime birthdate) : base(name, age, id, birthdate)
    {
    }
    public void BuyFood()
    {
        this.Food += 10;
    }
}
