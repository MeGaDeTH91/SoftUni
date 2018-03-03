﻿using System;

public class Cat : Animal, ISoundProducable
{
    public Cat(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string ProduceSound()
    {
        return  "Meow meow";
    }
}
