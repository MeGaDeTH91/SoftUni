namespace _03._Greedy_Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Bag bag = new Bag();

            long bagCapacity = long.Parse(Console.ReadLine());
            bag.Capacity = bagCapacity;
            bag.CashList = new List<Cash>();
            bag.GemList = new List<Gem>();
            bag.GoldList = new List<long>();

            string inputItems = Console.ReadLine();

            List<string> inputList = inputItems
                                     .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .ToList();

            while (inputList.Count > 1)
            {
                string firstArgument = inputList[0];
                string secondArgument = inputList[1];

                string lastThreeChars = string.Empty;
                if(firstArgument.Length > 3)
                {
                    int startIndex = Math.Max(0, (firstArgument.Length - 3));
                    lastThreeChars = firstArgument.Substring(startIndex, firstArgument.Length - startIndex);
                }
                if (firstArgument.ToLower() == "gold")
                {
                    long currentGoldAmount = long.Parse(secondArgument);

                    if(bag.Capacity >= currentGoldAmount)
                    {
                        bag.Capacity -= currentGoldAmount;
                        bag.GoldAmount += currentGoldAmount;
                        bag.GoldList.Add(currentGoldAmount);
                    }
                }
                else if(firstArgument.Length == 3)
                {
                    string currentCurrency = firstArgument;
                    long currentCashAmount = long.Parse(secondArgument);

                    if(bag.Capacity >= currentCashAmount && bag.CashAmount + currentCashAmount <= bag.GemAmount)
                    {
                        bag.Capacity -= currentCashAmount;
                        bag.CashAmount += currentCashAmount;

                        if(!bag.CashList.Any(x => x.Type.Equals(currentCurrency, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            Cash newCash = new Cash
                            {
                                Type = currentCurrency,
                                Quantity = currentCashAmount
                            };
                            bag.CashList.Add(newCash);
                        }
                        else
                        {
                            bag.CashList.FirstOrDefault(x => x.Type.Equals(currentCurrency, StringComparison.InvariantCultureIgnoreCase)).Quantity += currentCashAmount;
                        }
                    }
                }
                else if(lastThreeChars.ToLower() == "gem")
                {
                    string currentGem = firstArgument;
                    long currentGemAmount = long.Parse(secondArgument);

                    if (bag.Capacity >= currentGemAmount && bag.GemAmount + currentGemAmount <= bag.GoldAmount)
                    {
                        bag.Capacity -= currentGemAmount;
                        bag.GemAmount += currentGemAmount;

                        if (!bag.GemList.Any(x => x.Name.Equals(currentGem, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            Gem newGem = new Gem
                            {
                                Name = currentGem,
                                Quantity = currentGemAmount
                            };
                            bag.GemList.Add(newGem);
                        }
                        else
                        {
                            bag.GemList.FirstOrDefault(x => x.Name.Equals(currentGem, StringComparison.InvariantCultureIgnoreCase)).Quantity += currentGemAmount;
                        }
                    }
                }
                inputList.RemoveAt(0);
                inputList.RemoveAt(0);
            }
            if(bag.GoldList.Count > 0)
            {
                Console.WriteLine($"<Gold> ${bag.GoldAmount}");
                Console.WriteLine($"##Gold - {bag.GoldAmount}");
            }
            if(bag.GemList.Count > 0)
            {
                Console.WriteLine($"<Gem> ${bag.GemAmount}");
                foreach (var gem in bag.GemList.OrderByDescending(x => x.Name).ThenBy(x => x.Quantity))
                {
                    Console.WriteLine($"##{gem.Name} - {gem.Quantity}");
                }
            }
            if(bag.CashList.Count > 0)
            {
                Console.WriteLine($"<Cash> ${bag.CashAmount}");
                foreach (var cash in bag.CashList.OrderByDescending(x => x.Type).ThenBy(x => x.Quantity))
                {
                    Console.WriteLine($"##{cash.Type} - {cash.Quantity}");
                }
            }
        }
        public class Bag
        {
            public long Capacity { get; set; }
            public long GoldAmount { get; set; }
            public long CashAmount { get; set; }
            public long GemAmount { get; set; }
            public List<long> GoldList { get; set; }
            public List<Cash> CashList { get; set; }
            public List<Gem> GemList { get; set; }
        }
        public class Gem
        {
            public string Name { get; set; }

            public long Quantity { get; set; }
        }
        public class Cash
        {
            public string Type { get; set; }

            public long Quantity { get; set; }
        }
    }
}
