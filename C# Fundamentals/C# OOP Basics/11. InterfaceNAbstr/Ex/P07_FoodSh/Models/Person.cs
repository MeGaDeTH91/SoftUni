using System;

public class Person
{
    private string name;
    private int age;
    private string id;
    private DateTime birthdate;

    private string group;

    private int food;
    
    public string Group
    {
        get { return this.group; }
        private set { this.group = value; }
    }
    public string Id
    {
        get { return this.id; }
        private set { this.id = value; }
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }
    public int Age
    {
        get
        {
            return this.age;
        }
        private set
        {
            this.age = value;
        }
    }
    public DateTime Birthdate
    {
        get
        {
            return this.birthdate;
        }
        private set
        {
            this.birthdate = value;
        }
    }

    public int Food {
        get
        {
            return this.food;
        }
        set
        {
            this.food = value;
        }
    }

    public Person(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
    }

    public Person(string name, int age, string id, DateTime birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }
}