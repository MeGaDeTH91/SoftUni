using System;
using System.Collections.Generic;
using System.Text;

public class Person12
{
    public string Name { get; set; }
    public Company12 Company { get; set; }
    public Car12 Car { get; set; }
    public List<Pokemon12> Pokemons { get; set; }
    public List<Parent12> Parents { get; set; }
    public List<Child12> Children { get; set; }

    public Person12()
    {
        this.Pokemons  = new List<Pokemon12>();
        this.Parents = new List<Parent12>();
        this.Children = new List<Child12>();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Company:");
        if (this.Company != null)
        {
            sb.AppendLine(this.Company.ToString());
        }

        sb.AppendLine("Car:");
        if (this.Car != null)
        {
            sb.AppendLine(this.Car.ToString());
        }
        sb.AppendLine("Pokemon:");
        foreach (var poke in this.Pokemons)
        {
            sb.AppendLine(poke.ToString());
        }

        sb.AppendLine($"Parents:");
        foreach (var parent in this.Parents)
        {
            sb.AppendLine(parent.ToString());
        }
        sb.AppendLine($"Children:");
        foreach (var child in this.Children)
        {
            sb.AppendLine(child.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}

