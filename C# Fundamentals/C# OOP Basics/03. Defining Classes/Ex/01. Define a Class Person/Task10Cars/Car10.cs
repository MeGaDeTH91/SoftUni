using System;
using System.Collections.Generic;
using System.Text;

public class Car10
{
    public string Model { get; set; }

    public Engine10 Engine { get; set; }

    public string Weight { get; set; }

    public string Color { get; set; }
        
    public Car10()
    {

    }

    public Car10(string model, Engine10 engine)
    {
        this.Model = model;
        this.Engine = engine;
    }
    public Car10(string model, Engine10 engine, string weight)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
    }
    public Car10(string model, Engine10 engine, string weight, string color)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;
    }

    public override string ToString()
    {
        string currWeight = this.Weight != null ? this.Weight: "n/a";
        string currColor = this.Color != null ? this.Color : "n/a";
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Model}:");
        sb.AppendLine(this.Engine.ToString());
        sb.AppendLine($"  Weight: {currWeight}");
        sb.AppendLine($"  Color: {currColor}");
        return sb.ToString().TrimEnd();
    }
}

