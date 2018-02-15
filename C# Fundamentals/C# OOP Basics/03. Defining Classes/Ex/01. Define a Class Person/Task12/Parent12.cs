using System;
using System.Collections.Generic;
using System.Text;

public class Parent12
{
    public string Name { get; set; }

    public string BirthDay { get; set; }

    public Parent12()
    {

    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Name} {this.BirthDay}");
        return sb.ToString().TrimEnd();
    }
}
