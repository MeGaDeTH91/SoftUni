﻿using System;
using System.Collections.Generic;

public class RandomList : List<string>
{
    private Random rnd;

    public RandomList()
    {
        this.rnd = new Random();
    }

    public string RandomString()
    {
        int index = rnd.Next(0, this.Count - 1);
        string element = this[index];
        this.RemoveAt(index);
        return element;

    }
}
