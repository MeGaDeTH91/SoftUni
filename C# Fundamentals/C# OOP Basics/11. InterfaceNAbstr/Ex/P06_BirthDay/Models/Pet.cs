using System;

internal class Pet : WhiteWalker, IPet
{
    public Pet(string name, DateTime birthdate) : base(name, birthdate)
    {
    }
}
