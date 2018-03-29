using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] commTokens = command.Split().ToArray();

            string name = commTokens[0];
            int age = int.Parse(commTokens[1]);
            string town = commTokens[2];

            Person addPerson = new Person(name, age, town);
            people.Add(addPerson);
        }

        int index = int.Parse(Console.ReadLine()) - 1;
        Person seekPerson = people[index];
        List<Person> temp = people.Where(x => x.CompareTo(seekPerson) == 0).ToList();

        if(temp.Count < 2)
        {
            Console.WriteLine("No matches");
            return;
        }
        int notEqualPeople = people.Count - temp.Count;

        Console.WriteLine($"{temp.Count} {notEqualPeople} {people.Count}");

    }
}
