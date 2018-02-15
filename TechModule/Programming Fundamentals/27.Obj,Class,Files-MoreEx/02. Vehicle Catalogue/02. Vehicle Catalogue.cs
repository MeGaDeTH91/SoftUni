using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Vehicle_Catalogue
{
    class Car
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal HorsePower { get; set; }
    }
    class Truck
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal HorsePower { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> carList = new List<Car>();
            List<Truck> truckList = new List<Truck>();
            decimal carAver = 0;
            decimal truckAver = 0;
            string input = Console.ReadLine();

            while (input != "End")
            {
                Car currCar = new Car();
                Truck currTruck = new Truck();

                string[] currInput = input.Split(' ')
                    .ToArray();
                string currVehType = currInput[0].ToLower();
                string currVehModel = currInput[1];
                string currVehColor = currInput[2];
                decimal currVehPower = decimal.Parse(currInput[3]);

                if(currVehType == "car")
                {
                    currCar.Type = "Car";
                    currCar.Model = currVehModel;
                    currCar.Color = currVehColor;
                    currCar.HorsePower = currVehPower;
                    carList.Add(currCar);
                }
                else
                {
                    currTruck.Type = "Truck";
                    currTruck.Model = currVehModel;
                    currTruck.Color = currVehColor;
                    currTruck.HorsePower = currVehPower;
                    truckList.Add(currTruck);
                }
                input = Console.ReadLine();
            }
            if(carList.Count > 0)
            {
                 carAver = carList.Select(x => x.HorsePower).Average();
            }
            if(truckList.Count > 0)
            {
                 truckAver = truckList.Select(x => x.HorsePower).Average();
            }
            

            string modelInput = Console.ReadLine();

            while (modelInput != "Close the Catalogue")
            {
                foreach (var item in carList)
                {
                    if(item.Model.Contains(modelInput))
                    {
                        Console.WriteLine($"Type: {item.Type}");
                        Console.WriteLine($"Model: {item.Model}");
                        Console.WriteLine($"Color: {item.Color}");
                        Console.WriteLine($"Horsepower: {item.HorsePower}");
                    }
                }
                foreach (var item in truckList)
                {
                    if (item.Model.Contains(modelInput))
                    {
                        Console.WriteLine($"Type: {item.Type}");
                        Console.WriteLine($"Model: {item.Model}");
                        Console.WriteLine($"Color: {item.Color}");
                        Console.WriteLine($"Horsepower: {item.HorsePower}");
                    }
                }
                modelInput = Console.ReadLine();
            }
            Console.WriteLine($"Cars have average horsepower of: {carAver:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {truckAver:F2}.");
        }
    }
}
