using System;

internal class WhiteWalker
{
    private string name;
    private int age;

    private string model;
    private string id;

    public string Model
    {
        get { return this.model; }
        private set { this.model = value; }
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

    public WhiteWalker(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }

    public WhiteWalker(string name, int age, string id)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
    }
}