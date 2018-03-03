using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace P07_FoodSh
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Rebel> rebels = new Dictionary<string, Rebel>();
            Dictionary<string, Citizen> citizens = new Dictionary<string, Citizen>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commTokens = Console.ReadLine().Split();

                if(commTokens.Length == 4)
                {
                    string name = commTokens[0];
                    int age = int.Parse(commTokens[1]);
                    string id = commTokens[2];
                    DateTime birthdate = DateTime.ParseExact(commTokens[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    Citizen addCitizen = new Citizen(name, age, id, birthdate);
                    citizens.Add(name, addCitizen);
                }
                else if(commTokens.Length == 3)
                {
                    string name = commTokens[0];
                    int age = int.Parse(commTokens[1]);
                    string group = commTokens[2];

                    Rebel addRebel = new Rebel(name, age, group);
                    rebels.Add(name, addRebel);
                }
            }

            string command;
            while((command = Console.ReadLine()) != "End")
            {
                if(citizens.ContainsKey(command))
                {
                    citizens[command].BuyFood();
                }
                else if (rebels.ContainsKey(command))
                {
                    rebels[command].BuyFood();
                }
            }
            long result = citizens.Sum(x => x.Value.Food) + rebels.Sum(x => x.Value.Food);

            Console.WriteLine(result);
        }
    }
}
