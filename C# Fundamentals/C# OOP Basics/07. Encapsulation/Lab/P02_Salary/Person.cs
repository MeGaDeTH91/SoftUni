using System;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }

    public void IncreaseSalary(decimal bonus)
    {
        if(this.Age < 30)
        {
            this.salary += this.salary * (bonus / 100.0m) / 2.0m;
        }
        else
        {
            this.salary += this.salary * bonus / 100.0m;
        }
    }

    public decimal Salary
    {
        get
        {
            return this.salary;
        }
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
    }
}
