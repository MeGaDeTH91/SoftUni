using System;
using System.Collections.Generic;
using System.Text;

public class Worker : Human
{
    private decimal weekSalary;
    private double workHours;

    public Worker(string firstName, string lastName, decimal weekSalary, double workHours) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHours = workHours;
    }

    private decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        set
        {
            if(value < 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }
    private double WorkHours
    {
        get
        {
            return this.workHours;
        }
        set
        {
            if(value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workHours = value;
        }
    }

    public override string ToString()
    {
        double hourSalary = (double)(this.WeekSalary / 5) / this.WorkHours;

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"First Name: {base.FirstName}");
        sb.AppendLine($"Last Name: {base.LastName}");
        sb.AppendLine($"Week Salary: {this.WeekSalary:F2}");
        sb.AppendLine($"Hours per day: {this.WorkHours:F2}");
        sb.AppendLine($"Salary per hour: {hourSalary:F2}");

        return sb.ToString().TrimEnd();
    }
}
