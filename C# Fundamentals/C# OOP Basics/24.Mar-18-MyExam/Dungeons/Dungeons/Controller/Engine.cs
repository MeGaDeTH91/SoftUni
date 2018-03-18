using System;
using System.Linq;

public class Engine
{
    DungeonMaster dungeonMaster = new DungeonMaster();

    public void Run()
    {
        while (!dungeonMaster.IsGameOver())
        {
            try
            {
                string command = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(command))
                {
                    break;
                }

                string[] commTokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                string currentCommand = commTokens[0];

                switch (currentCommand)
                {
                    case "JoinParty":
                        Console.WriteLine(this.dungeonMaster.JoinParty(commTokens.Skip(1).ToArray()));
                        break;
                    case "AddItemToPool":
                        Console.WriteLine(this.dungeonMaster.AddItemToPool(commTokens.Skip(1).ToArray()));
                        break;
                    case "PickUpItem":
                        Console.WriteLine(this.dungeonMaster.PickUpItem(commTokens.Skip(1).ToArray()));
                        break;
                    case "UseItem":
                        Console.WriteLine(this.dungeonMaster.UseItem(commTokens.Skip(1).ToArray()));
                        break;
                    case "UseItemOn":
                        Console.WriteLine(this.dungeonMaster.UseItemOn(commTokens.Skip(1).ToArray()));
                        break;
                    case "GiveCharacterItem":
                        Console.WriteLine(this.dungeonMaster.GiveCharacterItem(commTokens.Skip(1).ToArray()));
                        break;
                    case "GetStats":
                        Console.WriteLine(this.dungeonMaster.GetStats());
                        break;
                    case "Attack":
                        Console.WriteLine(this.dungeonMaster.Attack(commTokens.Skip(1).ToArray()));
                        break;
                    case "Heal":
                        Console.WriteLine(this.dungeonMaster.Heal(commTokens.Skip(1).ToArray()));
                        break;
                    case "EndTurn":
                        Console.WriteLine(this.dungeonMaster.EndTurn(commTokens.Skip(1).ToArray()));
                        break;
                    case "IsGameOver":
                        this.dungeonMaster.IsGameOver();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                if(e is ArgumentException)
                {
                    Console.WriteLine($"Parameter Error: {e.Message}");
                }
                else if(e is InvalidOperationException)
                {
                    Console.WriteLine($"Invalid Operation: {e.Message}");
                }
            }

        }
        Console.WriteLine($"Final stats:");
        Console.WriteLine(dungeonMaster.GetStats());
    }
}
