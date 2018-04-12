namespace P05_KingsGambitExtended
{
    using P02_KingsGambit.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            HashSet<AbstractMan> warriors = new HashSet<AbstractMan>();
            Kingman theKing = new Kingman(Console.ReadLine());

            string[] royalGuards = Console.ReadLine().Split();
            string[] footmen = Console.ReadLine().Split();

            foreach (var royalGuard in royalGuards)
            {
                RoyalGuard currentRoyalGuard = new RoyalGuard(royalGuard);

                warriors.Add(currentRoyalGuard);
                theKing.KingIsDefinitelyUnderAttack += currentRoyalGuard.OnKingAttack;
            }

            foreach (var footman in footmen)
            {
                Footman currentFootman = new Footman(footman);

                warriors.Add(currentFootman);
                theKing.KingIsDefinitelyUnderAttack += currentFootman.OnKingAttack;
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commTokens = command.Split();

                string currentCommand = commTokens[0];

                switch (currentCommand)
                {
                    case "Attack":
                        theKing.OnKingAttack();
                        break;
                    case "Kill":
                        string nameToKill = commTokens[1];

                        var unitToKill = warriors.FirstOrDefault(x => x.Name.Equals(nameToKill));

                        if(unitToKill.HitTimesToDeath - 1 == 0)
                        {
                            theKing.KingIsDefinitelyUnderAttack -= unitToKill.OnKingAttack;
                            warriors.Remove(unitToKill);
                        }
                        else
                        {
                            unitToKill.HitTimesToDeath--;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
