namespace _03._Greedy_Times_II
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] itemsInput = Console.ReadLine()
                                  .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .ToArray();

            Dictionary<string, long> goldBag = new Dictionary<string, long>();
            long goldAmount = 0;

            Dictionary<string, long> gemBag = new Dictionary<string, long>();
            long gemAmount = 0;

            Dictionary<string, long> cashBag = new Dictionary<string, long>();
            long cashAmount = 0;

            for (int i = 0; i < itemsInput.Length; i+=2)
            {
                string itemName = itemsInput[i];
                long itemAmount = long.Parse(itemsInput[i + 1]);

                string itemType = GetItemType(itemName);

                bool canInsertItem = CanPutItemInBag(itemType, itemAmount, bagCapacity, goldAmount, gemAmount, cashAmount);                
                
                if(itemType == "Invalid" || !canInsertItem)
                {
                    continue;
                }

                switch (itemType)
                {
                    case "Gold":
                        InsertItem(goldBag, itemName, itemAmount);
                        goldAmount += itemAmount;
                        break;
                    case "Gem":
                        InsertItem(gemBag, itemName, itemAmount);
                        gemAmount += itemAmount;
                        break;
                    case "Cash":
                        InsertItem(cashBag, itemName, itemAmount);
                        cashAmount += itemAmount;
                        break;
                }
            }
            if (goldBag.Any())
            {
                Console.WriteLine(PrintBag(goldBag, "Gold", goldAmount));
                if (gemBag.Any())
                {
                    Console.WriteLine(PrintBag(gemBag, "Gem", gemAmount));
                    if (cashBag.Any())
                    {
                        Console.WriteLine(PrintBag(cashBag, "Cash", cashAmount));
                    }
                }
            }
        }

        private static string PrintBag(Dictionary<string, long> bag, string type, long totalAmount)
        {
            var resultBuilder = new StringBuilder();

            resultBuilder.AppendLine($"<{type}> ${totalAmount}");

            var orderedBag = bag.OrderByDescending(i => i.Key).ThenBy(i => i.Value);

            foreach (var item in orderedBag)
            {
                resultBuilder.AppendLine($"##{item.Key} - {item.Value}");
            }

            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }

        private static void InsertItem(Dictionary<string, long> bag, string itemName, long itemAmount)
        {
            if (!bag.ContainsKey(itemName))
            {
                bag[itemName] = 0;
            }

            bag[itemName] += itemAmount;
        }

        private static bool CanPutItemInBag(string itemType, long itemAmount, long bagCapacity, long goldAmount, long gemAmount, long cashAmount)
        {
            long bagCurrentTakenAmount = goldAmount + gemAmount + cashAmount;
            
            if (bagCapacity < bagCurrentTakenAmount + itemAmount)
            {
                return false;
            }
            switch (itemType)
            {
                case "Gold":
                    return true;
                case "Gem":
                    gemAmount += itemAmount;
                    return gemAmount <= goldAmount;
                case "Cash":
                    cashAmount += itemAmount;
                    return cashAmount <= gemAmount;
                default:
                    break;
            }
            return false;
        }

        private static string GetItemType(string itemName)
        {
            if(itemName.Length == 3)
            {
                return "Cash";
            }
            if (itemName.ToLower().EndsWith("gem") && itemName.Length >= 4)
            {
                return "Gem";
            }
            if (itemName.Equals("gold", StringComparison.InvariantCultureIgnoreCase))
            {
                return "Gold";
            }
            return "Invalid";
        }
    }
}
