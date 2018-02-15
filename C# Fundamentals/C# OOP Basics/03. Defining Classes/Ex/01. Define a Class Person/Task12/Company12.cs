using System;
using System.Collections.Generic;
using System.Text;

public class Company12
{
    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }

    public Company12()
    {

    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Name} {this.Department} {this.Salary:F2}");
        return sb.ToString().TrimEnd();
    }
}

