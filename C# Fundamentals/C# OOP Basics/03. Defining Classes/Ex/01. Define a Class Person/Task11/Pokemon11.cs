using System;
using System.Collections.Generic;
using System.Text;

public class Pokemon11
{
    public string Name { get; set; }
    public string Element { get; set; }
    public int Health { get; set; }

    public Pokemon11(string name, string element, int health)
    {
        this.Name = name;
        this.Element = element;
        this.Health = health;
    }

    public Pokemon11()
    {
    }
}

