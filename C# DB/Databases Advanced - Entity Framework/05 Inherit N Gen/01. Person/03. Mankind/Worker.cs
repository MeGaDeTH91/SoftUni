using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Worker : Human
{
    private decimal weekSalary;
    private decimal workingHours;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workingHours)
        :base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkingHours = workingHours;
    }

    public decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        set
        {
            if(value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }
    public decimal WorkingHours
    {
        get
        {
            return this.workingHours;
        }
        set
        {
            if(value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workingHours = value;
        }
    }
    public override string ToString()
    {
        decimal salaryPerHour = this.WeekSalary / (5 * this.WorkingHours);
        return $"First Name: {this.FirstName}" + Environment.NewLine +
            $"Last Name: {this.LastName}" + Environment.NewLine +
            $"Week Salary: {this.WeekSalary:F2}" + Environment.NewLine +
            $"Hours per day: {this.WorkingHours:F2}" + Environment.NewLine +
            $"Salary per hour: {salaryPerHour:F2}" + Environment.NewLine;
    }
}