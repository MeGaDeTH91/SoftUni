using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private Dictionary<string, Driver> Drivers;
    private List<Driver> SortedDrivers;
    private List<Driver> CrashedDrivers;
    private string Weather;
    private DriverFactory DriverFactory;
    private TyreFactory TyreFactory;
    private int TotalLaps;
    private int TotalTrackLength;
    private int currentLap = 0;
    public int remainingLaps;

    public RaceTower()
    {
        this.Drivers = new Dictionary<string, Driver>();
        this.CrashedDrivers = new List<Driver>();
        this.Weather = "Sunny";
        this.DriverFactory = new DriverFactory();
        this.TyreFactory = new TyreFactory();
        this.SortedDrivers = new List<Driver>();
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.TotalLaps = lapsNumber;
        this.TotalTrackLength = trackLength;
        this.remainingLaps = TotalLaps;
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            string name = commandArgs[1];
            this.Drivers.Add(name, this.DriverFactory.RegisterDriver(commandArgs));
        }
        catch { }
        
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string boxReason = commandArgs[0];
        string driverName = commandArgs[1];
        Driver currentDriver = this.Drivers[driverName];

        if (boxReason == "Refuel")
        {
            double fuelAmount = double.Parse(commandArgs[2]);

            currentDriver.Refuel(fuelAmount);
        }
        else if (boxReason == "ChangeTyres")
        {
            currentDriver.ChangeTyre(commandArgs.Skip(2).ToList());
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int numberOfLaps = int.Parse(commandArgs[0]);

        StringBuilder sb = new StringBuilder();

        if (numberOfLaps > this.remainingLaps)
        {
            try
            {
                throw new ArgumentException($"There is no time! On lap {currentLap}.");
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        
        for (int lap = 0; lap < numberOfLaps; lap++)
        {
            foreach (var driver in this.Drivers)
            {
                //Lap passes so we add time, reduce fuel and degradate tyres
                try
                {
                    driver.Value.IncreaseTime(this.TotalTrackLength);
                    driver.Value.ReduceFuel(this.TotalTrackLength);
                    driver.Value.Car.Tyre.DegradateTire();
                }
                catch (Exception failure)
                {
                    driver.Value.Status = failure.Message;
                }
            }

            this.currentLap++;
            this.remainingLaps--;

            this.SortedDrivers = this.Drivers.OrderByDescending(x => x.Value.TotalTime).Select(x => x.Value).ToList();

            //We check for overtakes
            TryToOvertake(sb);

            //We put the drivers that failed in the CrashedDrivers collection
            var temp = this.Drivers.Where(x => x.Value.Status != "Racing").Select(x => x.Value).ToList();
            this.CrashedDrivers.AddRange(temp);

            foreach (var driver in temp)
            {
                this.Drivers.Remove(driver.Name);
            }
        }

        if (remainingLaps == 0)
        {
            var driver = this.Drivers.OrderBy(x => x.Value.TotalTime).FirstOrDefault();
            sb.AppendLine($"{driver.Key} wins the race for {driver.Value.TotalTime:F3} seconds.");
        }

        return sb.ToString().Trim();
    }

    private void TryToOvertake(StringBuilder sb)
    {
        for (int index = 0; index < this.SortedDrivers.Count - 1; index++)
        {
            var driver = this.SortedDrivers[index];
            var nextDriver = this.SortedDrivers[index + 1];

            bool weHaveOvertake = false;

            try
            {
                var timeDifference = driver.TotalTime - nextDriver.TotalTime;

                bool aggressiveDriverWithUltrasoft = driver is AggressiveDriver && driver.Car.Tyre is UltrasoftTyre && timeDifference <= 3;
                bool enduranceDriverWithHard = driver is EnduranceDriver && driver.Car.Tyre is HardTyre && timeDifference <= 3;

                if (aggressiveDriverWithUltrasoft)
                {
                    if (this.Weather == "Foggy")
                    {
                        throw new ArgumentException("Crashed");
                    }
                    this.Drivers[driver.Name].OverTake(3.0d);
                    this.Drivers[nextDriver.Name].LosePosition(3.0d);
                    AppendOverTakeToSb(sb, driver.Name, nextDriver.Name);
                    weHaveOvertake = true;
                }
                else if (enduranceDriverWithHard)
                {
                    if (this.Weather == "Rainy")
                    {
                        throw new ArgumentException("Crashed");
                    }
                    this.Drivers[driver.Name].OverTake(3.0d);
                    this.Drivers[nextDriver.Name].LosePosition(3.0d);
                    AppendOverTakeToSb(sb, driver.Name, nextDriver.Name);
                    weHaveOvertake = true;
                }
                else if (timeDifference <= 2)
                {
                    if (IsAggressiveAndFoggy(driver.GetType().Name))
                    {
                        throw new ArgumentException("Crashed");
                    }
                    if (IsEnduranceAndRainy(driver.GetType().Name))
                    {
                        throw new ArgumentException("Crashed");
                    }
                    this.Drivers[driver.Name].OverTake(2.0d);
                    this.Drivers[nextDriver.Name].LosePosition(2.0d);
                    AppendOverTakeToSb(sb, driver.Name, nextDriver.Name);
                    weHaveOvertake = true;
                }
                if (weHaveOvertake)
                {
                    index++;
                }
            }
            catch (Exception e)
            {
                this.Drivers[driver.Name].Status = e.Message;
            }
        }
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Lap {currentLap}/{TotalLaps}");
        int counter = 1;
        foreach (var driver in this.Drivers.OrderBy(x => x.Value.TotalTime).Where(x => x.Value.Status == "Racing"))
        {
            sb.AppendLine($"{counter++} {driver.Key} {driver.Value.TotalTime:F3}");
        }
        for (int i = this.CrashedDrivers.Count - 1; i >= 0; i--)
        {
            var driver = this.CrashedDrivers[i];
            sb.AppendLine($"{counter++} {driver.Name} {driver.Status}");
        }

        return sb.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string newWeather = commandArgs[0];
        this.Weather = newWeather;
    }

    private void AppendOverTakeToSb(StringBuilder sb, string driver, string nextDriver)
    {
        sb.AppendLine($"{driver} has overtaken {nextDriver} on lap {this.currentLap}.");
    }

    private bool IsEnduranceAndRainy(string driverType)
    {
        return driverType == "EnduranceDriver" && this.Weather == "Rainy";
    }

    private bool IsAggressiveAndFoggy(string driverType)
    {
        return driverType == "AggressiveDriver" && this.Weather == "Foggy";
    }
}
