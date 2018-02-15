using _04.Speed_Racing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main()
    {
        List<Car> cars = new List<Car>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] args = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string model = args[0];
            decimal fuelAmount = decimal.Parse(args[1]);
            decimal fuelConsumption = decimal.Parse(args[2]);
            if(!cars.Any(x => x.Model == model))
            {
                Car currentCar = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(currentCar);
            }
        }
        string command;

        while ((command =Console.ReadLine()) != "End")
        {
            string[] commArgs = command
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string carModel = commArgs[1];
            int currDistance = int.Parse(commArgs[2]);

            Car car = cars.Find(x => x.Model == carModel);

            bool IsMoved = car.Drive(currDistance);
            if(!IsMoved)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
        foreach (var c in cars)
        {
            Console.WriteLine($"{c.Model} {c.FuelAmount:F2} {c.TravelDistance}");
        }
    }
}

