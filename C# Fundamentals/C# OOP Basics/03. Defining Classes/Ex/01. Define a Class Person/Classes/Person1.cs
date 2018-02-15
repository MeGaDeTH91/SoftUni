using System;
using System.Collections.Generic;
using System.Text;

public class Person1
{
    private string name;
    private int age;

    public Person1()
    {
        this.Name = "No name";
        this.Age = 1;
    }
    public Person1(int age)
    {
        this.Name = "No name";
        this.Age = age;
    }
    public Person1(string name, int age)
    {
        this.Name = name;
        this.Age = age;
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

    public override string ToString()
    {
        return $"{this.Name} - {this.Age}";
    }
}

