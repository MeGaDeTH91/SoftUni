namespace _02.TravellingPoliceman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int fuel = 0;
        private static List<Street> allStreets;
        private static int[,] maxPrice;
        private static bool[,] takeItems;

        public static void Main()
        {
            ReadInput();

            TakeItems();

            PrintResult();
        }

        private static void TakeItems()
        {
            for (int row = 1; row <= allStreets.Count; row++)
            {
                Street street = allStreets[row - 1];

                for (int col = 1; col <= fuel; col++)
                {
                    int takeValue = 0;
                    int noTakeValue = maxPrice[row - 1, col];

                    if (street.Length <= col)
                    {
                        takeValue = maxPrice[row - 1, col - street.Length] + street.StreetValue;
                    }


                    if (takeValue > noTakeValue)
                    {
                        maxPrice[row, col] = takeValue;
                        takeItems[row, col] = true;
                    }
                    else
                    {
                        maxPrice[row, col] = noTakeValue;
                    }
                }
            }
        }

        private static void PrintResult()
        {
            List<Street> chosen = new List<Street>();

            int remainingFuel = fuel;

            for (int i = allStreets.Count; i > 0; i--)
            {
                if (takeItems[i, remainingFuel])
                {
                    chosen.Add(allStreets[i - 1]);
                    remainingFuel -= allStreets[i - 1].Length;
                }
            }

            chosen.Reverse();

            long totalPokemons = chosen.Sum(x => x.Pokemons);
            long totalCarDmg = chosen.Sum(x => x.CarDamage);

            Console.WriteLine(string.Join(" -> ", chosen.Select(x => x.Name)));
            Console.WriteLine($"Total pokemons caught -> {totalPokemons}");
            Console.WriteLine($"Total car damage -> {totalCarDmg}");
            Console.WriteLine($"Fuel Left -> {remainingFuel}");
        }
        
        private static void ReadInput()
        {
            allStreets = new List<Street>();

            fuel = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input
                    .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = tokens[0];
                int carDamage = int.Parse(tokens[1]);
                int pokemons = int.Parse(tokens[2]);
                int length = int.Parse(tokens[3]);
                int streetValue = pokemons * 10 - carDamage;

                Street street = new Street()
                {
                    Name = name,
                    CarDamage = carDamage,
                    Pokemons = pokemons,
                    Length = length,
                    StreetValue = streetValue
                };

                allStreets.Add(street);
            }

            maxPrice = new int[allStreets.Count + 1, fuel + 1];
            takeItems = new bool[allStreets.Count + 1, fuel + 1];
        }

        private class Street
        {
            public string Name { get; set; }

            public int CarDamage { get; set; }

            public int Pokemons { get; set; }

            public int Length { get; set; }

            public int StreetValue { get; set; }
        }
    }
}
