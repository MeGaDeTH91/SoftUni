using System;

public class Dog : Animal, ISoundProducable
{
    public Dog(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string ProduceSound()
    {
        return "Woof!";
    }
}
