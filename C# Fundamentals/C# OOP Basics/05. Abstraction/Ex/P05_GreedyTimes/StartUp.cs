using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] lockerContent = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long goldAmount = 0;
            long gemAmount = 0;
            long cashAmount = 0;

            for (int i = 0; i < lockerContent.Length; i += 2)
            {
                string currContent = lockerContent[i];
                long contentAmount = long.Parse(lockerContent[i + 1]);

                string contentType = GetMeContentType(currContent, contentAmount);

                if (contentType == "")
                {
                    continue;
                }
                else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + contentAmount)
                {
                    continue;
                }

                bool checkContent = IsContentValid(contentType, contentAmount, bag);
                if (!checkContent)
                {
                    continue;
                }

                if (!bag.ContainsKey(contentType))
                {
                    bag[contentType] = new Dictionary<string, long>();
                }

                if (!bag[contentType].ContainsKey(currContent))
                {
                    bag[contentType][currContent] = 0;
                }

                FillBag(currContent, contentType, contentAmount, ref bag, goldAmount, gemAmount, cashAmount);
            }
            PrintBag(bag);
        }

        private static void FillBag(string currContent, string contentType, long contentAmount, ref Dictionary<string, Dictionary<string, long>> bag, long goldAmount, long gemAmount, long cashAmount)
        {
            bag[contentType][currContent] += contentAmount;
            if (contentType == "Gold")
            {
                goldAmount += contentAmount;
            }
            else if (contentType == "Gem")
            {
                gemAmount += contentAmount;
            }
            else if (contentType == "Cash")
            {
                cashAmount += contentAmount;
            }
        }

        private static bool IsContentValid(string contentType, long contentAmount, Dictionary<string, Dictionary<string, long>> bag)
        {
            switch (contentType)
            {
                case "Gem":
                    if (!bag.ContainsKey(contentType))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (contentAmount > bag["Gold"].Values.Sum())
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (bag[contentType].Values.Sum() + contentAmount > bag["Gold"].Values.Sum())
                    {
                        return false;
                    }
                    break;
                case "Cash":
                    if (!bag.ContainsKey(contentType))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (contentAmount > bag["Gem"].Values.Sum())
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (bag[contentType].Values.Sum() + contentAmount > bag["Gem"].Values.Sum())
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }

        private static string GetMeContentType(string currContent, long contentAmount)
        {
            string contentType = string.Empty;

            if (currContent.Length == 3)
            {
                contentType = "Cash";
            }
            else if (currContent.ToLower().EndsWith("gem"))
            {
                contentType = "Gem";
            }
            else if (currContent.ToLower() == "gold")
            {
                contentType = "Gold";
            }

            return contentType;
        }

        private static void PrintBag(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var item in bag)
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");
                foreach (var item2 in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}