using System;
using System.Linq;

public class Engine
{
    private CarManager carManager;

    public Engine()
    {
        this.carManager = new CarManager();
    }

    public void Run()
    {
        string command;
        while ((command = Console.ReadLine()) != "Cops Are Here")
        {
            string[] commTokens = command.Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToArray();

            string currentCommand = commTokens[0];
            int id = int.Parse(commTokens[1]);

            switch (currentCommand)
            {
                case "register":
                    string carType = commTokens[2];
                    string brand = commTokens[3];
                    string model = commTokens[4];
                    int yearOfProduction = int.Parse(commTokens[5]);
                    int horsepower = int.Parse(commTokens[6]);
                    int acceleration = int.Parse(commTokens[7]);
                    int suspension = int.Parse(commTokens[8]);
                    int durability = int.Parse(commTokens[9]);

                    this.carManager.Register(id, carType, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                    break;
                case "check":
                    Console.WriteLine(this.carManager.Check(id));
                    break;
                case "open":
                    string raceType = commTokens[2];
                    int length = int.Parse(commTokens[3]);
                    string route = commTokens[4];
                    int prizePool = int.Parse(commTokens[5]);
                    if(commTokens.Length > 6)
                    {
                        int extraParameter = int.Parse(commTokens[6]);
                        this.carManager.Open(id, raceType, length, route, prizePool, extraParameter);
                    }
                    else
                    {
                        this.carManager.Open(id, raceType, length, route, prizePool);
                    }                    
                    break;
                case "participate":
                    int carId = id;
                    int raceId = int.Parse(commTokens[2]);
                    this.carManager.Participate(carId, raceId);
                    break;
                case "start":
                    int startRaceId = id;
                    Console.WriteLine(this.carManager.Start(startRaceId));
                    break;
                case "park":
                    int carParkId = id;
                    this.carManager.Park(carParkId);
                    break;
                case "unpark":
                    int carUnparkId = id;
                    this.carManager.Unpark(carUnparkId);
                    break;
                case "tune":
                    int tuneIndex = id;
                    string addOn = commTokens[2];
                    this.carManager.Tune(tuneIndex, addOn);
                    break;
                default:
                    break;
            }
        }
    }
}
