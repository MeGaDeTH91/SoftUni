using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Person> people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            Person currPerson = new Person();

            string[] args = Console.ReadLine()
                .Split(' ').ToArray();
            string name = args[0];
            int age = int.Parse(args[1]);
            currPerson.Name = name;
            currPerson.Age = age;

            people.Add(currPerson);
        }

        foreach (var p in people.OrderBy(x => x.Name).Where(x => x.Age > 30))
        {
            Console.WriteLine($"{p.Name} - {p.Age}");
        }
    }
}
