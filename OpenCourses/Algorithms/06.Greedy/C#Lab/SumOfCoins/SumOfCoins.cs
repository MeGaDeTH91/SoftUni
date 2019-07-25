using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = Console.ReadLine()
            .Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var targetSum = int.Parse(Console.ReadLine());

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        Dictionary<int, int> chosenCoins = new Dictionary<int, int>();

        coins = coins.OrderByDescending(x => x).ToList();

        for (int index = 0; index < coins.Count; index++)
        {
            int currentCoin = coins[index];

            while (currentCoin <= targetSum && targetSum > 0)
            {
                if (!chosenCoins.ContainsKey(currentCoin))
                {
                    chosenCoins[currentCoin] = 0;
                }

                if (targetSum - currentCoin < 0 && index == coins.Count - 1)
                {
                    break;
                }
                else
                {
                    int coinsToTake = targetSum / currentCoin;
                    chosenCoins[currentCoin] += coinsToTake;
                    targetSum -= currentCoin * coinsToTake;
                }
            }
        }

        if (targetSum != 0)
        {
            throw new InvalidOperationException("");
        }
        return chosenCoins;
    }
}