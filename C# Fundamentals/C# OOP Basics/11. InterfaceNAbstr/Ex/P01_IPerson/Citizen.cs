internal class Citizen : IPerson
{
    private string name;
    private int age;

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
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
        private set
        {
            this.age = value;
        }
    }

    public Citizen(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}