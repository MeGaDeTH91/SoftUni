using System;
using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person1> familyMembers;

    public Family()
    {
        familyMembers = new List<Person1>();
    }

    public void AddMember(Person1 member)
    {
        familyMembers.Add(member);
    }
    public Person1 GetOldestMember()
    {
        int greatestAge = familyMembers.Max(x => x.Age);
        var oldestPerson = familyMembers.FirstOrDefault(x => x.Age == greatestAge);

        return oldestPerson;
    }
}


