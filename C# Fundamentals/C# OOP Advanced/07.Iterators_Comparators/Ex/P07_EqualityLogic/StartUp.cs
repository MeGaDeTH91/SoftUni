using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main(string[] args)
    {
        SortedSet<Person> sortedPeople = new SortedSet<Person>();
        HashSet<Person> hashedPeople = new HashSet<Person>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] personTokens = Console.ReadLine().Split();

            string name = personTokens[0];
            int age = int.Parse(personTokens[1]);

            Person addPerson = new Person(name, age);

            sortedPeople.Add(addPerson);
            hashedPeople.Add(addPerson);
        }

        Console.WriteLine(sortedPeople.Count);
        Console.WriteLine(hashedPeople.Count);
    }
}
