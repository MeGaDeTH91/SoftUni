using System;
using System.Collections.Generic;

namespace P03_WildFarm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                ReadAddAndTryToFeedAnimal(animals, command);
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static void ReadAddAndTryToFeedAnimal(List<Animal> animals, string command)
        {
            string[] commTokens = command.Split();
            string animalType = commTokens[0];
            string name = commTokens[1];
            double weight = double.Parse(commTokens[2]);

            switch (animalType)
            {
                case "Owl":
                    double owlWingSize = double.Parse(commTokens[3]);

                    Animal newOwl = new Owl(name, weight, owlWingSize);
                    Console.WriteLine(newOwl.ProduceSound());
                    TryToFeedAnimal(newOwl, animalType);
                    animals.Add(newOwl);
                    break;
                case "Hen":
                    double henWingSize = double.Parse(commTokens[3]);

                    Animal newHen = new Hen(name, weight, henWingSize);
                    Console.WriteLine(newHen.ProduceSound());
                    TryToFeedAnimal(newHen, animalType);
                    animals.Add(newHen);
                    break;
                case "Mouse":
                    string mouseLivingRegion = commTokens[3];

                    Animal newMouse = new Mouse(name, weight, mouseLivingRegion);
                    Console.WriteLine(newMouse.ProduceSound());
                    TryToFeedAnimal(newMouse, animalType);
                    animals.Add(newMouse);
                    break;
                case "Dog":
                    string dogLivingRegion = commTokens[3];

                    Animal newDog = new Dog(name, weight, dogLivingRegion);
                    Console.WriteLine(newDog.ProduceSound());
                    TryToFeedAnimal(newDog, animalType);
                    animals.Add(newDog);
                    break;
                case "Cat":
                    string catLivingRegion = commTokens[3];
                    string catBreed = commTokens[4];

                    Animal newCat = new Cat(name, weight, catLivingRegion, catBreed);
                    Console.WriteLine(newCat.ProduceSound());
                    TryToFeedAnimal(newCat, animalType);
                    animals.Add(newCat);
                    break;
                case "Tiger":
                    string tigerLivingRegion = commTokens[3];
                    string tigerBreed = commTokens[4];

                    Animal newTiger = new Tiger(name, weight, tigerLivingRegion, tigerBreed);
                    Console.WriteLine(newTiger.ProduceSound());
                    TryToFeedAnimal(newTiger, animalType);
                    animals.Add(newTiger);
                    break;
                default:
                    break;
            }
        }

        private static void TryToFeedAnimal(Animal animal, string animalType)
        {
            string[] foodInput = Console.ReadLine().Split();
            string foodType = foodInput[0];
            int foodQuantity = int.Parse(foodInput[1]);

            animal.FeedAnimal(foodType, foodQuantity);
        }
    }
}
