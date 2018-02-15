using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>();
        string command;

        while ((command = Console.ReadLine()) != "Beast!")
        {
            string animalType = command;
            string[] input = Console.ReadLine().Split().ToArray();

            string name = input[0];
            int age = int.Parse(input[1]);
            string gender = input[2];
            try
            {
                switch (animalType.ToLower())
                {
                    case "dog":
                        var dog = new Dog(name, age, gender);
                        animals.Add(dog);
                        break;
                    case "frog":
                        var frog = new Frog(name, age, gender);
                        animals.Add(frog);
                        break;
                    case "cat":
                        var cat = new Cat(name, age, gender);
                        animals.Add(cat);
                        break;
                    case "kitten":
                        var kitten = new Kitten(name, age, gender);
                        animals.Add(kitten);
                        break;
                    case "tomcat":
                        var tomcat = new Tomcat(name, age, gender);
                        animals.Add(tomcat);
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                }
            }


            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);

            }
            
        }
        foreach (var a in animals)
        {
            Console.WriteLine(a);
        }
    }
}