using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Organization : IOrganization
{
    Dictionary<string, List<Person>> peopleByName;
    HashSet<Person> hashPeople;
    List<Person> indexedPeople;

    public Organization()
    {
        this.peopleByName = new Dictionary<string, List<Person>>();
        this.hashPeople = new HashSet<Person>();
        this.indexedPeople = new List<Person>();
    }

    public int Count => this.indexedPeople.Count;

    public bool Contains(Person person)
    {
        return this.hashPeople.Contains(person);
    }

    public bool ContainsByName(string name)
    {
        return this.peopleByName.ContainsKey(name);
    }

    public void Add(Person person)
    {
        this.indexedPeople.Add(person);
        this.hashPeople.Add(person);
        if (!this.peopleByName.ContainsKey(person.Name))
        {
            this.peopleByName[person.Name] = new List<Person>();
        }
        this.peopleByName[person.Name].Add(person);
    }

    public Person GetAtIndex(int index)
    {
        if(this.indexedPeople.Count < index)
        {
            throw new IndexOutOfRangeException();
        }
        return this.indexedPeople[index];
    }

    public IEnumerable<Person> GetByName(string name)
    {
        var temp = new List<Person>();
        if (this.peopleByName.ContainsKey(name))
        {
            temp = peopleByName[name];
        }
        return temp;
    }

    public IEnumerable<Person> FirstByInsertOrder(int count = 1)
    {
        return this.indexedPeople.Take(count).ToList();
    }

    public IEnumerable<Person> SearchWithNameSize(int minLength, int maxLength)
    {
        var temp = this.peopleByName.Where(x => x.Key.Length >= minLength && x.Key.Length <= maxLength);

        var people = new List<Person>();

        foreach (var currList in temp)
        {
            people.AddRange(currList.Value);
        }
        return people;
    }

    public IEnumerable<Person> GetWithNameSize(int length)
    {
        var temp = this.peopleByName.Where(x => x.Key.Length == length );

        var people = new List<Person>();

        foreach (var currList in temp)
        {
            people.AddRange(currList.Value);
        }

        if (people.Count < 1)
        {
            throw new ArgumentException();
        }
        return people;
    }

    public IEnumerable<Person> PeopleByInsertOrder()
    {
        return this.indexedPeople;
    }

    public IEnumerator<Person> GetEnumerator()
    {
        foreach (var emp in this.indexedPeople)
        {
            yield return emp;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}