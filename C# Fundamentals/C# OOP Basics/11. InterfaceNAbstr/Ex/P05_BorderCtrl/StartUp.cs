using System;
using System.Collections.Generic;

namespace P05_BorderCtrl
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

                if(commTokens.Length == 3)
                {
                    Citizen newCitizen = new Citizen(commTokens[0], int.Parse(commTokens[1]), commTokens[2]);

                    walkers.Add(newCitizen);
                }
                else if(commTokens.Length == 2)
                {
                    Robot addRobot = new Robot(commTokens[0], commTokens[1]);
                    walkers.Add(addRobot);
                }
            }

            string seekEndId = Console.ReadLine();
            foreach (var walker in walkers)
            {
                if (walker.Id.EndsWith(seekEndId))
                {
                    Console.WriteLine(walker.Id);
                }
            }
        }
    }
}
