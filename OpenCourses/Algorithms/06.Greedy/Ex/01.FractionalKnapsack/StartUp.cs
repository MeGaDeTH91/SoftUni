namespace _01.FractionalKnapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static IList<Item> items = new List<Item>();
        private static double capacity = 0.0d;
        private static double price = 0.0d;

        public static void Main()
        {
            ReadInput();

            TakeItems();

            Console.WriteLine($"Total price: {price:F2}");
        }

        private static void TakeItems()
        {
            foreach (var item in items)
            {
                if (capacity - item.Weight >= 0)
                {
                    Console.WriteLine($"Take 100% of item with price {item.Price:F2} and weight {item.Weight:F2}");

                    price += item.Price;
                    capacity -= item.Weight;
                }
                else
                {
                    double remainigPercentage = capacity / item.Weight;
                    double resultPercentage = remainigPercentage * 100.0d;

                    Console.WriteLine($"Take {resultPercentage:F2}% of item with price {item.Price:F2} and weight {item.Weight:F2}");

                    price += item.Price * remainigPercentage;
                    capacity -= item.Weight * remainigPercentage;
                    break;
                }
            }
        }

        private static void ReadInput()
        {
            capacity = double.Parse(Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1]);
            int itemCount = int.Parse(Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1]);

            for (int i = 0; i < itemCount; i++)
            {
                string[] currentTokens = Console.ReadLine()
                    .Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Item currentItem = new Item()
                {
                    Price = double.Parse(currentTokens[0]),
                    Weight = double.Parse(currentTokens[1])
                };

                items.Add(currentItem);
            }

            items = items.OrderByDescending(x => x.Price / x.Weight).ToList();
        }

        private class Item
        {
            public double Price { get; set; }

            public double Weight { get; set; }
        }
    }
}
