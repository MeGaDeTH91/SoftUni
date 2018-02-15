using System;
using System.Collections.Generic;
using System.Text;

public class Trainer11
{
    public string Name { get; set; }
    public int BadgeNumber { get; set; }
    public List<Pokemon11> Pokemons { get; set; }
    
    public Trainer11(string name, int badgeNumber)
    {
        this.Name = name;
        this.BadgeNumber = badgeNumber;
        this.Pokemons = new List<Pokemon11>();
    }
    public Trainer11()
    {
        this.Pokemons = new List<Pokemon11>();
    }
}

