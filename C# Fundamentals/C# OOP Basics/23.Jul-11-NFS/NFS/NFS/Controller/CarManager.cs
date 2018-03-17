using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Dictionary<int, Race> closedRaces;
    private Garage garage;
    private CarFactory carFactory;
    private RaceFactory raceFactory;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
        this.carFactory = new CarFactory();
        this.raceFactory = new RaceFactory();
        this.closedRaces = new Dictionary<int, Race>();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        Car car = this.carFactory.RegisterCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        this.cars.Add(id, car);
    }

    public string Check(int id)
    {
        return this.cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        Race race = this.raceFactory.OpenRace(type, length, route, prizePool);
        this.races.Add(id, race);
    }

    public void Open(int id, string type, int length, string route, int prizePool, int extraParameter)
    {
        Race race = this.raceFactory.OpenRace(type, length, route, prizePool, extraParameter);
        this.races.Add(id, race);
    }

    public void Participate(int carId, int raceId)
    {
        Car car = this.cars[carId];
        Race race = this.races[raceId];

        if (car.Status != "Parked")
        {
            if(race.GetType().Name == "TimeLimitRace" && race.ParticipantCount == 0 || race.GetType().Name != "TimeLimitRace")
            {
                car.SetNewStatus("Racing");
                this.races[raceId].AddParticipant(car);
            }
        }
    }

    public string Start(int id)
    {
        Race race = this.races[id];

        if (race.ParticipantCount == 0)
        {
            return $"Cannot start the race with zero participants.";
        }

        StringBuilder sb = new StringBuilder();
        
        ExecuteRace(race, sb);

        foreach (var car in race.Participants)
        {
            car.SetNewStatus("Ready");
        }
        this.closedRaces.Add(id, race);
        this.races.Remove(id);

        return sb.ToString().Trim();
    }
    
    public void Park(int id)
    {
        Car car = this.cars[id];
        foreach (var race in races)
        {
            if (race.Value.Participants.Contains(car))
            {
                return;
            }
        }

        car.SetNewStatus("Parked");
        this.garage.ParkCarInGarage(car);
    }

    public void Unpark(int id)
    {
        Car car = this.cars[id];

        if (car.Status == "Parked")
        {
            car.SetNewStatus("Ready");
            this.garage.UnparkCarInGarage(car);
        }
    }

    public void Tune(int tuneIndex, string addOn)
    {
        if(this.garage.NumberOfParkedCars  == 0)
        {
            return;
        }
        foreach (var car in this.garage.ParkedCars)
        {
            car.Tune(tuneIndex, addOn);
        }
    }

    private static void ExecuteRace(Race race, StringBuilder sb)
    {
        bool casualRace = race is CasualRace;
        bool dragRace = race is DragRace;
        bool driftRace = race is DriftRace;
        bool timeLimitRace = race is TimeLimitRace;
        bool circuitRace = race is CircuitRace;

        List<Car> winners = new List<Car>();

        int noWinnerHere = 0;
        int firstPrize = (race.PrizePool * 50) / 100;
        int secondPrize = (race.PrizePool * 30) / 100;
        int thirdPrize = (race.PrizePool * 20) / 100;
        List<int> prizes = new List<int>() { noWinnerHere, firstPrize, secondPrize, thirdPrize };

        int numberOfWinners = Math.Min(3, race.Participants.Count);
        int position = 1;

        if (casualRace)
        {
            sb.AppendLine($"{race.Route} - {race.Length}");

            winners = race.Participants.OrderByDescending(x => x.OverallPerformance).Take(numberOfWinners).ToList();

            foreach (var car in winners)
            {
                sb.AppendLine($"{position}. {car.Brand} {car.Model} {car.OverallPerformance}PP - ${prizes[position]}");
                position++;
            }
        }
        else if (dragRace)
        {
            sb.AppendLine($"{race.Route} - {race.Length}");
            winners = race.Participants.OrderByDescending(x => x.EnginePerformance).Take(numberOfWinners).ToList();

            foreach (var car in winners)
            {
                sb.AppendLine($"{position}. {car.Brand} {car.Model} {car.EnginePerformance}PP - ${prizes[position]}");
                position++;
            }
        }
        else if (driftRace)
        {
            sb.AppendLine($"{race.Route} - {race.Length}");
            winners = race.Participants.OrderByDescending(x => x.SuspensionPerformance).Take(numberOfWinners).ToList();

            foreach (var car in winners)
            {
                sb.AppendLine($"{position}. {car.Brand} {car.Model} {car.SuspensionPerformance}PP - ${prizes[position]}");
                position++;
            }
        }
        else if (timeLimitRace)
        {
            Car participant = race.Participants.First();
            int timePerformance = race.Length * ((participant.Horsepower / 100) * participant.Acceleration);
            string earnedTime = string.Empty;
            int wonPrize = 0;
            int timeDifference = race.GoldTime - timePerformance;


            sb.AppendLine($"{race.Route} - {race.Length}");

            if (timeDifference >= 0)
            {
                earnedTime = "Gold";
                wonPrize = race.PrizePool;
            }
            else if(timeDifference >= -15)
            {
                earnedTime = "Silver";
                wonPrize = (race.PrizePool * 50) / 100;
            }
            else
            {
                earnedTime = "Bronze";
                wonPrize = (race.PrizePool * 30) / 100;
            }
            sb.AppendLine($"{participant.Brand} {participant.Model} - {timePerformance} s.");
            sb.AppendLine($"{earnedTime} Time, ${wonPrize}.");
        }
        else if (circuitRace)
        {
            int circuitFirstPrize = (race.PrizePool * 40) / 100;
            int circuitSecondPrize = (race.PrizePool * 30) / 100;
            int circuitThirdPrize = (race.PrizePool * 20) / 100;
            int circuitFourthPrize = (race.PrizePool * 10) / 100;

            prizes = new List<int>() { noWinnerHere, circuitFirstPrize, circuitSecondPrize, circuitThirdPrize, circuitFourthPrize };

            numberOfWinners = Math.Min(4, race.Participants.Count);

            sb.AppendLine($"{race.Route} - {race.Length * race.Laps}");
            winners = race.Participants.OrderByDescending(x => x.OverallPerformance).Take(numberOfWinners).ToList();

            foreach (var car in race.Participants)
            {
                car.DecreaseDurability(race.Laps, race.Length);
            }
            
            foreach (var car in winners)
            {
                sb.AppendLine($"{position}. {car.Brand} {car.Model} {car.OverallPerformance}PP - ${prizes[position]}");
                position++;
            }
        }
    }
}
