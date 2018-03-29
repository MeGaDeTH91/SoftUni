using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main(string[] args)
    {
        SortedSet<Person> byNames = new SortedSet<Person>(new NameComparator());
        SortedSet<Person> byAges = new SortedSet<Person>(new AgeComparator());

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] currentPerson = Console.ReadLine().Split();

            string name = currentPerson[0];
            int age = int.Parse(currentPerson[1]);

            Person addPerson = new Person(name, age);

            byNames.Add(addPerson);
            byAges.Add(addPerson);
        }

        foreach (var person in byNames)
        {
            Console.WriteLine(person);
        }
        foreach (var person in byAges)
        {
            Console.WriteLine(person);
        }
    }
}
