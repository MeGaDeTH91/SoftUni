using System;

public class Pet : IComparable<Pet>
{
    public string Name { get; set; }

    public int Age { get; set; }

    public string Kind { get; set; }

    public Pet(string name, int age, string kind)
    {
        this.Name = name;
        this.Age = age;
        this.Kind = kind;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age} {this.Kind}";
    }

    public int CompareTo(Pet other)
    {
        int result = this.Name.CompareTo(other.Name);
        if(result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }
        return result;
    }
}
