using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Family
{
    private List<Person> people;

    public Family()
    {
        this.people = new List<Person>();
    }

    public void AddMember(Person member)
    {
        People.Add(member);
    }

    public Person GetOldestMember()
    {
        return People.OrderByDescending(x => x.Age).First();
    }

    public List<Person> People
    {
        get
        {
            return this.people;
        }
        set
        {
            this.people = value;
        }
    }
}