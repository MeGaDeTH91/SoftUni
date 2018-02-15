using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Order_by_Age
{
    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public long Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Person> peoples = new List<Person>();

            while (input != "End")
            {
                string[] currInput = input.Split(' ')
                    .ToArray();
                Person currPerson = new Person();
                string currName = currInput[0];
                string currId = currInput[1];
                long currAge = long.Parse(currInput[2]);
                currPerson.Name = currName;
                currPerson.ID = currId;
                currPerson.Age = currAge;
                peoples.Add(currPerson);

                input = Console.ReadLine();

            }
            foreach (var item in peoples.OrderBy(x => x.Age))
            {
                Console.WriteLine($"{item.Name} with ID: {item.ID} is {item.Age} years old.");
            }
        }
    }
}
