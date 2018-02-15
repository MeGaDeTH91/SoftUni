using System;
using System.Collections.Generic;
using System.Text;

public class Pokemon12
{
    public string Name { get; set; }
    public string Type { get; set; }

    public Pokemon12()
    {

    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Name} {this.Type}");
        return sb.ToString().TrimEnd();
    }
}
