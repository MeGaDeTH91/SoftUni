using System;
using System.Collections.Generic;
using System.Text;

public class Car12
{
    public string Model { get; set; }

    public int Speed { get; set; }

    public Car12()
    {
        
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Model} {this.Speed}");
        return sb.ToString().TrimEnd();
    }
}
