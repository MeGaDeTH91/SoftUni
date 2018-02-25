using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Program
{
    static void Main(string[] args)
    {
        string isItDatePattern = @"^(?<date2>[0-9]{1,2}\/[0-9]{1,2}\/[0-9]{1,4})$";
        string nameNamePattern = @"^(?<firstFirstName>[\w]+)\s(?<firstLastName>[\w]+)\s+[-]\s+(?<secondFirstName>[\w]+)\s(?<secondLastName>[\w]+)$";
        string nameDateDashPattern = @"^(?<FirstName>[\w]+)\s(?<LastName>[\w]+)\s+[-]\s+(?<date>[0-9]{1,2}\/[0-9]{1,2}\/[0-9]{1,4})$";
        string nameDateNoDashPattern = @"^(?<FirstName>[\w]+)\s(?<LastName>[\w]+)\s+(?<date>[0-9]{1,2}\/[0-9]{1,2}\/[0-9]{1,4})$";
        string dateNamePattern = @"^(?<date>[0-9]{1,2}\/[0-9]{1,2}\/[0-9]{1,4})\s+[-]\s+(?<FirstName>[\w]+)\s(?<LastName>[\w]+)$";
        string dateDatePattern = @"^(?<date1>[0-9]{1,2}\/[0-9]{1,2}\/[0-9]{1,4})\s+[-]\s+(?<date2>[0-9]{1,2}\/[0-9]{1,2}\/[0-9]{1,4})$";

        Regex rgxNameName = new Regex(nameNamePattern);
        Regex rgxNameDateDash = new Regex(nameDateDashPattern);
        Regex rgxNameDateNoDash = new Regex(nameDateNoDashPattern);
        Regex rgxDateName = new Regex(dateNamePattern);
        Regex rgxDateDate = new Regex(dateDatePattern);

        Queue<string> familyTies = new Queue<string>();

        string seekNameOrBD = Console.ReadLine();
        List<Person> people = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {

            Match type5Match = rgxNameDateNoDash.Match(input);

            if (type5Match.Success)
            {
                string firstName = type5Match.Groups["FirstName"].Value;
                string lastName = type5Match.Groups["LastName"].Value;
                string fullName = $"{firstName} {lastName}";

                string birthDate = type5Match.Groups["date"].Value;
                Person addPerson = new Person()
                {
                    Name = fullName,
                    BirthDate = birthDate
                };
                people.Add(addPerson);
            }
            else
            {
                familyTies.Enqueue(input);
            }
        }

        while (familyTies.Count > 0)
        {
            string currCommand = familyTies.Dequeue();

            Match type1Match = rgxNameName.Match(currCommand);
            Match type2Match = rgxNameDateDash.Match(currCommand);
            Match type3Match = rgxDateName.Match(currCommand);
            Match type4Match = rgxDateDate.Match(currCommand);

            if (type1Match.Success)
            {
                string parentFirstName = type1Match.Groups["firstFirstName"].Value;
                string parentLastName = type1Match.Groups["firstLastName"].Value;
                string parentName = $"{parentFirstName} {parentLastName}";

                string childFirstName = type1Match.Groups["secondFirstName"].Value;
                string childLastName = type1Match.Groups["secondLastName"].Value;
                string childName = $"{childFirstName} {childLastName}";

                var parent = people.FirstOrDefault(x => x.Name == parentName);
                var child = people.FirstOrDefault(x => x.Name == childName);

                parent.Children.Add($"{child.Name} {child.BirthDate}");
                child.Parents.Add($"{parent.Name} {parent.BirthDate}");
            }
            else if (type2Match.Success)
            {
                string parentFirstName = type2Match.Groups["FirstName"].Value;
                string parentLastName = type2Match.Groups["LastName"].Value;
                string parentName = $"{parentFirstName} {parentLastName}";

                string childBirthDate = type2Match.Groups["date"].Value;

                var parent = people.FirstOrDefault(x => x.Name == parentName);
                var child = people.FirstOrDefault(x => x.BirthDate == childBirthDate);

                parent.Children.Add($"{child.Name} {child.BirthDate}");
                child.Parents.Add($"{parent.Name} {parent.BirthDate}");
            }
            else if (type3Match.Success)
            {
                string parentBirthDate = type3Match.Groups["date"].Value;

                string childFirstName = type3Match.Groups["FirstName"].Value;
                string childLastName = type3Match.Groups["LastName"].Value;
                string childName = $"{childFirstName} {childLastName}";



                var parent = people.FirstOrDefault(x => x.BirthDate == parentBirthDate);
                var child = people.FirstOrDefault(x => x.Name == childName);

                parent.Children.Add($"{child.Name} {child.BirthDate}");
                child.Parents.Add($"{parent.Name} {parent.BirthDate}");
            }
            else if (type4Match.Success)
            {
                string parentBirthDate = type4Match.Groups["date1"].Value;
                string childBirthDate = type4Match.Groups["date2"].Value;

                var parent = people.FirstOrDefault(x => x.BirthDate == parentBirthDate);
                var child = people.FirstOrDefault(x => x.BirthDate == childBirthDate);

                parent.Children.Add($"{child.Name} {child.BirthDate}");
                child.Parents.Add($"{parent.Name} {parent.BirthDate}");
            }
        }

        Regex isItDatergx = new Regex(isItDatePattern);
        Person printPerson;
        if (isItDatergx.IsMatch(seekNameOrBD))
        {
            printPerson = people.FirstOrDefault(x => x.BirthDate == seekNameOrBD);
        }
        else
        {
            printPerson = people.FirstOrDefault(x => x.Name == seekNameOrBD);
        }

        Console.WriteLine(printPerson.ToString());
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
}


