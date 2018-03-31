using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Organization : IOrganization
{
    private List<Person> employees;
    private Dictionary<string, double> peopleWithName;
    private Dictionary<Person, double> fullPeople;

    public Organization()
    {
        this.employees = new List<Person>();
        this.peopleWithName = new Dictionary<string, double>();
        this.fullPeople = new Dictionary<Person, double>();
    }

    public IEnumerator<Person> GetEnumerator()
    {
        foreach (var emp in this.employees)
        {
            yield return emp;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public int Count => this.employees.Count;

    public bool Contains(Person person)
    {
        return this.fullPeople.ContainsKey(person);
    }

    public bool ContainsByName(string name)
    {
        return this.peopleWithName.ContainsKey(name);
    }

    public void Add(Person person)
    {
        this.employees.Add(person);
        if (!this.peopleWithName.ContainsKey(person.Name))
        {
            this.peopleWithName[person.Name] = person.Salary;
        }
        if (!this.fullPeople.ContainsKey(person))
        {
            this.fullPeople[person] = person.Salary;
        }
    }

    public Person GetAtIndex(int index)
    {
        if(index > this.Count)
        {
            throw new IndexOutOfRangeException();
        }
        return this.employees[index];
    }

    public IEnumerable<Person> GetByName(string name)
    {
        var temp = this.employees.Where(x => x.Name == name).ToList();
        return temp;
    }

    public IEnumerable<Person> FirstByInsertOrder(int count = 1)
    {
        return this.employees.Take(count);
    }

    public IEnumerable<Person> SearchWithNameSize(int minLength, int maxLength)
    {
        return this.employees.Where(x => x.Name.Length >= minLength && x.Name.Length <= maxLength);
    }

    public IEnumerable<Person> GetWithNameSize(int length)
    {
        var temp = this.employees.Where(x => x.Name.Length == length).ToList();
        
        if(temp.Count < 1)
        {
            throw new ArgumentException();
        }
        return temp;
    }

    public IEnumerable<Person> PeopleByInsertOrder()
    {
        return this.employees;
    }
}