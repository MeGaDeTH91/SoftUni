using System;
using System.Text;

public class Citizen : IPerson, IResident
{
    private string name;
    private int age;
    private string country;

    public Citizen(string name, string country, int age)
    {
        this.Name = name;
        this.Age = age;
        this.Country = country;
    }

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
    public string Country
    {
        get
        {
            return this.country;
        }
        set
        {
            this.country = value;
        }
    }

    string IPerson.GetName()
    {
        return this.Name;
    }

    string IResident.GetName()
    {
        return $"Mr/Ms/Mrs {this.Name}";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(((IPerson)this).GetName());
        sb.AppendLine(((IResident)this).GetName());
        return sb.ToString().TrimEnd();
    }
}
