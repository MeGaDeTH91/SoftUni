using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var familyTree = new List<Person>();
            string seekPersonInput = Console.ReadLine();
            Queue<KeyValuePair<string, string>> familyRelations = new Queue<KeyValuePair<string, string>>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" - ");
                if (tokens.Length > 1)
                {
                    familyRelations.Enqueue(new KeyValuePair<string, string>(tokens[0], tokens[1]));
                }
                else
                {
                    tokens = tokens[0].ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    AddFamilyMember(familyTree, tokens);
                }
            }

            ArrangeRelations(familyTree, familyRelations);

            PrintPersonFamilyTree(familyTree, seekPersonInput);
        }
                
        private static void PrintPersonFamilyTree(List<Person> familyTree, string seekPersonInput)
        {
            Person printPerson;

            if (IsBirthday(seekPersonInput))
            {
                printPerson = familyTree.FirstOrDefault(x => x.Birthday == seekPersonInput);
            }
            else
            {
                printPerson = familyTree.FirstOrDefault(x => x.Name == seekPersonInput);
            }

            Console.WriteLine(printPerson);
            Console.WriteLine("Parents:");
            foreach (var parent in printPerson.Parents)
            {
                Console.WriteLine(parent);
            }
            Console.WriteLine("Children:");
            foreach (var child in printPerson.Children)
            {
                Console.WriteLine(child);
            }
        }

        private static void ArrangeRelations(List<Person> familyTree, Queue<KeyValuePair<string, string>> familyRelations)
        {
            while (familyRelations.Count > 0)
            {
                var currPair = familyRelations.Dequeue();

                string firstPerson = currPair.Key;
                string secondPerson = currPair.Value;

                Person currentPerson;

                if (IsBirthday(firstPerson))
                {
                    currentPerson = familyTree.FirstOrDefault(p => p.Birthday == firstPerson);

                    SetChild(familyTree, currentPerson, secondPerson);
                }
                else
                {
                    currentPerson = familyTree.FirstOrDefault(p => p.Name == firstPerson);

                    SetChild(familyTree, currentPerson, secondPerson);
                }
            }
        }

        private static void AddFamilyMember(List<Person> familyTree, string[] tokens)
        {
            string name = $"{tokens[0]} {tokens[1]}";
            string birthday = tokens[2];

            Person person = new Person
            {
                Name = name,
                Birthday = birthday
            };
            familyTree.Add(person);
        }

        private static void SetChild(List<Person> familyTree, Person parentPerson, string childNameOrDate)
        {
            var childPerson = new Person();

            if (IsBirthday(childNameOrDate))
            {
                childPerson = familyTree.First(p => p.Birthday == childNameOrDate);
            }
            else
            {
                childPerson = familyTree.First(p => p.Name == childNameOrDate);
            }
            parentPerson.Children.Add(childPerson);
            childPerson.Parents.Add(parentPerson);
        }

        static bool IsBirthday(string input)
        {
            return char.IsDigit(input[0]);
        }
    }
}
