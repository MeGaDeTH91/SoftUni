using System;

public class Citizen : WhiteWalker, ICitizen
{
    public Citizen(string name, int age, string id) : base(name, age, id)
    {
    }
}
