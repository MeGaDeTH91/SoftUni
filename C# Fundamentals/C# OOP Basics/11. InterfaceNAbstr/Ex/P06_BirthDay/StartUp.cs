using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace P06_BirthDay
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //For 100/100 please change every internal to public
            List<WhiteWalker> walkers = new List<WhiteWalker>();
            
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commTokens = command.Split();

                if(commTokens.Length == 5)
                {
                    string name = commTokens[1];
                    int age = int.Parse(commTokens[2]);
                    string id = commTokens[3];
                    DateTime birthday = DateTime.ParseExact(commTokens[4], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    Citizen addCitizen = new Citizen(name, age, id, birthday);
                    walkers.Add(addCitizen);
                }
                else
                {
                    DateTime birthday;
                    bool isBirthDay = DateTime.TryParseExact(commTokens[2], "dd/MM/yyyy",CultureInfo.InvariantCulture, DateTimeStyles.None, out birthday);
                    if (isBirthDay)
                    {
                        string name = commTokens[1];
                        Pet addPet = new Pet(name, birthday);
                        walkers.Add(addPet);
                    }
                    else
                    {
                        string model = commTokens[1];
                        Robot addRobot = new Robot(model, commTokens[2]);
                        walkers.Add(addRobot);
                    }
                }
            }

            int seekYear = int.Parse(Console.ReadLine());

            walkers = walkers.Where(x => x.Birthdate.Year == seekYear).ToList();

            foreach (var walker in walkers)
            {
                Console.WriteLine(walker.Birthdate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            }
        }
    }
}
