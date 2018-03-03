using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    private List<Private> privates;

    public List<Private> Privates
    {
        get { return privates; }
        set { privates = value; }
    }

    public LeutenantGeneral(int id, string firstName, string lastName, decimal salary, List<Private> privates) : base(id, firstName, lastName, salary)
    {
        this.Privates = privates;
    }

    public LeutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
    {
        this.Privates = new List<Private>();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

         sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
        sb.AppendLine("Privates:");
        foreach (var currPrivate in this.Privates)
        {
            sb.AppendLine(currPrivate.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}
