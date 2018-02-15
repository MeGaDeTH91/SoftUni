using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Trainlands
{
    class Wagons
    {
        public string WagonName { get; set; }
        public long WagonPower { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<Wagons>> trains = new Dictionary<string, List<Wagons>>();

            while (input != "It's Training Men!")
            {
                string[] arr = input.Split(new char[] { ' ', '-', '>', ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (arr.Length == 3 && arr[1] != "=")
                {
                    string currTrainName = arr[0];
                    string currWagonName = arr[1];
                    long currWagonPw = long.Parse(arr[2]);
                    Wagons currWag = new Wagons()
                    {
                        WagonName = currWagonName,
                        WagonPower = currWagonPw
                    };
                    if (trains.ContainsKey(currTrainName))
                    {
                        trains[currTrainName].Add(currWag);
                    }
                    else
                    {
                        trains[currTrainName] = new List<Wagons>();
                        trains[currTrainName].Add(currWag);
                    }
                }
                else
                {
                    string[] equalArr = input.Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                    string[] pointArr = input.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                    if (pointArr.Length == 2)
                    {
                        string trainName = pointArr[0];
                        string otherTrain = pointArr[1];

                        if (trains.ContainsKey(trainName))
                        {
                            for (int i = 0; i < trains[otherTrain].Count; i++)
                            {
                                trains[trainName].Add(trains[otherTrain][i]);
                            }
                            trains.Remove(otherTrain);
                        }
                        else
                        {
                            trains[trainName] = new List<Wagons>(trains[otherTrain]);
                            trains.Remove(otherTrain);
                        }
                    }
                    else if (equalArr.Length == 2)
                    {
                        string trainName = equalArr[0];
                        string otherTrain = equalArr[1];

                        if (trains.ContainsKey(trainName))
                        {
                            trains[trainName] = new List<Wagons>(trains[otherTrain]);
                        }
                        else
                        {
                            trains[trainName] = new List<Wagons>(trains[otherTrain]);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var currTrain in trains.Keys.OrderByDescending(x => trains[x].Sum(i => i.WagonPower)).ThenBy(x => trains[x].Count))
            {
                Console.WriteLine($"Train: {currTrain}");
                foreach (var wagons in trains[currTrain].OrderByDescending(x => x.WagonPower))
                {
                    Console.WriteLine($"###{wagons.WagonName} - {wagons.WagonPower}");
                }
            }
        }
    }
}
