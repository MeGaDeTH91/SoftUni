using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    private List<Repair> repairs;
    public List<Repair> Repairs
    {
        get { return this.repairs; }
        set { this.repairs = value; }
    }

    public Engineer(int id, string firstName, string lastName, decimal salary, CorpsType corps, List<Repair> repairs) : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = repairs;
    }

    public Engineer(int id, string firstName, string lastName, decimal salary, CorpsType corps) : base(id, firstName, lastName, salary, corps)
    {
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
        sb.AppendLine($"Corps: {this.Corps.ToString()}");
        sb.AppendLine($"Repairs:");
        foreach (var repair in this.Repairs)
        {
            sb.AppendLine(repair.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}
