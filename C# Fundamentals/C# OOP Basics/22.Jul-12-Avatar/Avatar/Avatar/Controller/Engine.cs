using System;
using System.Linq;

public class Engine
{
    NationsBuilder nationsBuilder = new NationsBuilder();

    public void Run()
    {
        string command;
        while ((command = Console.ReadLine()) != "Quit")
        {
            string[] commTokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            string commType = commTokens[0];

            switch (commType)
            {
                case "Bender":
                    this.nationsBuilder.AssignBender(commTokens.Skip(1).ToList());
                    break;
                case "Monument":
                    this.nationsBuilder.AssignMonument(commTokens.Skip(1).ToList());
                    break;
                case "Status":
                    string statusNationsType = commTokens[1];
                    Console.WriteLine(this.nationsBuilder.GetStatus(statusNationsType));
                    break;
                case "War":
                    string warNationsType = commTokens[1];
                    this.nationsBuilder.IssueWar(warNationsType);
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine(this.nationsBuilder.GetWarsRecord());
    }
}
