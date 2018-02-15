using System;
using System.Collections.Generic;
using System.Text;

public class Employee
{
    private string name;
    private int age;
    private decimal salary;
    private string position;
    private string department;
    private string email;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }
    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
        }
    }
    public decimal Salary
    {
        get
        {
            return this.salary;
        }
        set
        {
            this.salary = value;
        }
    }
    public string Position
    {
        get
        {
            return this.position;
        }
        set
        {
            this.position = value;
        }
    }
    public string Department
    {
        get
        {
            return this.department;
        }
        set
        {
            this.department = value;
        }
    }
    public string Email
    {
        get
        {
            return this.email;
        }
        set
        {
            this.email = value;
        }
    }


}

