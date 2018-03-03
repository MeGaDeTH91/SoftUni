namespace P06_Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class P06_Animals
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string animalType;
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] secondLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = secondLine[0];
                int age = int.Parse(secondLine[1]);
                string gender = secondLine[2];

                try
                {
                    switch (animalType.ToLower())
                    {
                        case "dog":
                            Dog newDog = new Dog(name, age, gender);
                            animals.Add(newDog);
                            break;
                        case "cat":
                            Cat newCat = new Cat(name, age, gender);
                            animals.Add(newCat);
                            break;
                        case "frog":
                            Frog newFrog = new Frog(name, age, gender);
                            animals.Add(newFrog);
                            break;
                        case "kitten":
                            Kitten newKitten = new Kitten(name, age, gender);
                            animals.Add(newKitten);
                            break;
                        case "tomcat":
                            Tomcat newTomcat = new Tomcat(name, age, gender);
                            animals.Add(newTomcat);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            foreach (var currAnimal in animals)
            {
                Console.WriteLine(currAnimal);
            }
        }
    }
}
