using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }

        int n = int.Parse(Console.ReadLine());
        Family family = new Family();

        for (int i = 0; i < n; i++)
        {
            Person tempPerson = new Person();
            string[] input = Console.ReadLine()
                .Split().ToArray();
            string name = input[0];
            int age = int.Parse(input[1]);

            tempPerson.Name = name;
            tempPerson.Age = age;

            family.AddMember(tempPerson);
        }
        var oldest = family.GetOldestMember();
        Console.WriteLine(oldest.Name + " " + oldest.Age);
    }
}
