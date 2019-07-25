namespace _01.KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int capacity = 0;
        private static List<Item> allItems = new List<Item>();
        private static int[,] maxPrice;
        private static bool[,] takeItems;

        public static void Main()
        {
            ReadInputInitialize();

            TakeItems();

            PrintResult();
        }

        private static void PrintResult()
        {
            List<Item> chosen = new List<Item>();

            int remainingCapacity = capacity;

            for (int i = allItems.Count; i > 0; i--)
            {
                if(takeItems[i, remainingCapacity])
                {
                    chosen.Add(allItems[i - 1]);
                    remainingCapacity -= allItems[i - 1].Weight;
                }
            }

            int totalWeight = chosen.Sum(x => x.Weight);
            int totalValue = chosen.Sum(x => x.Value);

            Console.WriteLine($"Total Weight: {totalWeight}");
            Console.WriteLine($"Total Value: {totalValue}");

            chosen = chosen.OrderBy(x => x.Name).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, chosen.Select(x => x.Name)));
        }

        private static void TakeItems()
        {
            for (int row = 1; row <= allItems.Count; row++)
            {
                Item item = allItems[row - 1];

                for (int col = 1; col <= capacity; col++)
                {
                    int takeValue = 0;
                    int noTakeValue = maxPrice[row - 1, col];

                    if (item.Weight <= col)
                    {
                        takeValue = maxPrice[row - 1, col - item.Weight] + item.Value;
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

        private static void ReadInputInitialize()
        {
            capacity = int.Parse(Console.ReadLine());

            string line;
            while ((line = Console.ReadLine()) != "end")
            {
                string[] tokens = line
                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = tokens[0];
                int weight = int.Parse(tokens[1]);
                int value = int.Parse(tokens[2]);

                Item item = new Item()
                {
                    Name = name,
                    Value = value,
                    Weight = weight
                };
                allItems.Add(item);
            }

            maxPrice = new int[allItems.Count + 1, capacity + 1];
            takeItems = new bool[allItems.Count + 1, capacity + 1];
        }

        private class Item
        {
            public string Name { get; set; }

            public int Value { get; set; }

            public int Weight { get; set; }
        }
    }
}
