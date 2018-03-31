using System.Collections.Generic;

public class Launcher
{
    public static void Main()
    {
        IOrganization org = new Organization();
        List<Person> people = new List<Person>
        {
            new Person("Ivan", 350),
            new Person("Pesho", 1200),
            new Person("Mitko", 20),
            new Person("Maria", 0),
            new Person("Stamat", 1500),
            new Person("Alex", 850),
            new Person("Rosi", 3000)
        };

        // Act
        foreach (Person person in people)
        {
            org.Add(person);
        }
    }
}
