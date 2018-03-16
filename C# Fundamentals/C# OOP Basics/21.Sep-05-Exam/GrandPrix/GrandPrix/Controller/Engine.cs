using System;
using System.Linq;

public class Engine
{
    RaceTower raceTower = new RaceTower();

    public void Run()
    {
        int lapsNumber = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());

        this.raceTower.SetTrackInfo(lapsNumber, trackLength);

        while (true)
        {
            try
            {
                string[] commTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string currentCommand = commTokens[0];

                switch (currentCommand)
                {
                    case "RegisterDriver":
                        this.raceTower.RegisterDriver(commTokens.Skip(1).ToList());
                        break;
                    case "Leaderboard":
                        Console.WriteLine(this.raceTower.GetLeaderboard());
                        break;
                    case "CompleteLaps":
                        string complete = this.raceTower.CompleteLaps(commTokens.Skip(1).ToList());
                        if (!string.IsNullOrWhiteSpace(complete))
                        {
                            Console.WriteLine(complete);
                        }
                        
                        if(this.raceTower.remainingLaps == 0)
                        {
                            return;
                        }
                        break;
                    case "Box":
                        this.raceTower.DriverBoxes(commTokens.Skip(1).ToList());
                        break;
                    case "ChangeWeather":
                        this.raceTower.ChangeWeather(commTokens.Skip(1).ToList());
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
