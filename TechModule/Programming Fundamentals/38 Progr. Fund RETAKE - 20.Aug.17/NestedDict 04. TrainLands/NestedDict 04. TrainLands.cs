using System;
using System.Collections.Generic;
using System.Linq;




class Trainlands
{
    static void Main()
    {
        var trains = new Dictionary<string, Dictionary<string, long>>();

        while (true)
        {
            var input = Console.ReadLine();

            if (input == "It's Training Men!")
            {
                break;
            }

            var trainName = "";
            if (input.Contains(':'))
            {
                trainName = input.Split('-')[0].Trim();
                var wagonName = input.Split('>', ':')[1].Trim();
                var wagonPower = int.Parse(input.Split(':')[1].Trim());

                if (!trains.ContainsKey(trainName))
                {
                    trains[trainName] = new Dictionary<string, long>();
                }

                trains[trainName][wagonName] = wagonPower;
            }

            else if (input.Contains('='))
            {
                trainName = input.Split('=')[0].Trim();
                var otherTrain = input.Split('=')[1].Trim();

                trains[trainName] = new Dictionary<string, long>(trains[otherTrain]);

            }

            else
            {
                trainName = input.Split('-')[0].Trim();
                var otherTrain = input.Split('>')[1].Trim();

                if (!trains.ContainsKey(trainName))
                {
                    trains[trainName] = new Dictionary<string, long>();
                }

                foreach (var wagon in trains[otherTrain])
                {
                    trains[trainName].Add(wagon.Key, wagon.Value);
                }

                trains.Remove(otherTrain);
            }
        }

        foreach (var train in trains.Keys.OrderByDescending(x => trains[x].Values.Sum()).ThenBy(x => trains[x].Count))
        {
            Console.WriteLine($"Train: {train}");

            foreach (var wagon in trains[train].Keys.OrderByDescending(x => trains[train][x]))
            {
                Console.WriteLine($"###{wagon} - {trains[train][wagon]}");
            }
        }
    }
}