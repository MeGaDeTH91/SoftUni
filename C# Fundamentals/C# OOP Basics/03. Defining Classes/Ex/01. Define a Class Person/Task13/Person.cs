using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public string Name { get; set; }

    public string BirthDate { get; set; }

    public List<string> Parents { get; set; }
    public List<string> Children { get; set; }

    public Person()
    {
        this.Parents = new List<string>();
        this.Children = new List<string>();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Name} {this.BirthDate}");
        return sb.ToString().TrimEnd();
    }
}

