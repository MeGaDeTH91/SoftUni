using System;
using System.Collections.Generic;
using System.Text;

public class Child12
{
    public string Name { get; set; }

    public string BirthDay { get; set; }

    public Child12()
    {

    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Name} {this.BirthDay}");
        return sb.ToString().TrimEnd();
    }
}
