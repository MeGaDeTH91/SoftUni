using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> familyMembers;

    public Family()
    {
        familyMembers = new List<Person>();
    }

    public void AddMember(Person member)
    {
        familyMembers.Add(member);
    }
    //public Person GetOldestMember()
    //{
    //    int greatestAge = this.familyMembers.Max(x => x.Age);
    //    var oldestPerson = this.familyMembers.FirstOrDefault(x => x.Age == greatestAge);
        
    //    return oldestPerson;
    //}
}
