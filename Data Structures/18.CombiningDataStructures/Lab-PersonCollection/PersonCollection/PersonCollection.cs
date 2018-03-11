using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    Dictionary<string, Person> personByEmail;

    OrderedDictionary<string, SortedSet<Person>> personByDomain;
    OrderedDictionary<string, SortedSet<Person>> personByNameAndTown;
    OrderedDictionary<int, SortedSet<Person>> personByAgeRange;
    Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personByTownAndAge;
    // TODO: define the underlying data structures here ...

    public PersonCollection()
    {
        this.personByEmail = new Dictionary<string, Person>();
        this.personByDomain = new OrderedDictionary<string, SortedSet<Person>>();
        this.personByNameAndTown = new OrderedDictionary<string, SortedSet<Person>>();
        this.personByAgeRange = new OrderedDictionary<int, SortedSet<Person>>();
        this.personByTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        // TODO: implement this
        if (!this.personByEmail.ContainsKey(email))
        {
            
            Person addPerson = new Person(email, name, age, town);
            personByEmail.Add(email, addPerson);
            AddByDomain(email, addPerson);
            AddByNameAndTown(name, town, addPerson);
            AddByAge(age, addPerson);
            AddByTownAndAge(town, age, addPerson);
            return true;
        }
        return false;
    }

    private void AddByTownAndAge(string town, int age, Person person)
    {
        if (!this.personByTownAndAge.ContainsKey(town))
        {
            this.personByTownAndAge[town] = new OrderedDictionary<int, SortedSet<Person>>();
        }
        if (!this.personByTownAndAge[town].ContainsKey(age))
        {
            this.personByTownAndAge[town][age] = new SortedSet<Person>();
        }
        this.personByTownAndAge[town][age].Add(person);
    }

    private void AddByAge(int age, Person addPerson)
    {
        if (!this.personByAgeRange.ContainsKey(age))
        {
            this.personByAgeRange[age] = new SortedSet<Person>();
        }
        this.personByAgeRange[age].Add(addPerson);
    }

    private void AddByNameAndTown(string name, string town, Person addPerson)
    {
        string currKey = GetMeNameTownKey(name, town);
        if (!this.personByNameAndTown.ContainsKey(currKey))
        {
            this.personByNameAndTown[currKey] = new SortedSet<Person>();
        }
        this.personByNameAndTown[currKey].Add(addPerson);
    }

    private string GetMeNameTownKey(string name, string town)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(name);
        sb.Append(town);
        return sb.ToString();
    }

    private void AddByDomain(string email, Person addPerson)
    {
        string currDomain = GetDomain(email);
        if (!this.personByDomain.ContainsKey(currDomain))
        {
            this.personByDomain[currDomain] = new SortedSet<Person>();
        }
        this.personByDomain[currDomain].Add(addPerson);
    }

    private string GetDomain(string email)
    {
        int index = email.IndexOf("@") + 1;
        int length = email.Length - index;
        string domain = email.Substring(index, length);
        return domain;
    }

    public int Count => this.personByEmail.Count;

    public Person FindPerson(string email)
    {
        // TODO: implement this
        if (this.personByEmail.ContainsKey(email))
        {
            return this.personByEmail[email];
        }
        else
        {
            return null;
        }
    }

    public bool DeletePerson(string email)
    {
        // TODO: implement this
        if (this.personByEmail.ContainsKey(email))
        {
            var person = personByEmail[email];
            this.personByEmail.Remove(email);
            this.personByDomain[GetDomain(person.Email)].Remove(person);
            this.personByNameAndTown[GetMeNameTownKey(person.Name, person.Town)].Remove(person);
            this.personByAgeRange[person.Age].Remove(person);
            this.personByTownAndAge[person.Town][person.Age].Remove(person);
            return true;
        }
        return false;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        // TODO: implement this
        var personList = new List<Person>();
        if (this.personByDomain.ContainsKey(emailDomain))
        {
            personList = this.personByDomain[emailDomain].ToList();
        }
        return personList;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        // TODO: implement this
        string currKey = GetMeNameTownKey(name, town);
        var personList = new List<Person>();
        if (this.personByNameAndTown.ContainsKey(currKey))
        {
            personList = this.personByNameAndTown[currKey].ToList();
        }
        return personList;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        // TODO: implement this
        var personRange = this.personByAgeRange.Range(startAge, true, endAge, true);

        foreach (var kvp in personRange)
        {
            foreach (var person in kvp.Value)
            {
                yield return person;
            }            
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (this.personByTownAndAge.ContainsKey(town))
        {
            var personRange = this.personByTownAndAge[town].Range(startAge, true, endAge, true);
            // TODO: implement this
            foreach (var kvp in personRange)
            {
                foreach (var person in kvp.Value)
                {
                    yield return person;
                }
            }
        }
    }
}
