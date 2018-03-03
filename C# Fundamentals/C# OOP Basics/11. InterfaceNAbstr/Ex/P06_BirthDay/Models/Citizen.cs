using System;

internal class Citizen : WhiteWalker, ICitizen
{
    public Citizen(string name, int age, string id, DateTime birthdate) : base(name, age, id, birthdate)
    {
    }
}
