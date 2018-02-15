using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            
            string[] input = Console.ReadLine()
                .Split().ToArray();
            string currModel = input[0];
            int speed = int.Parse(input[1]);
            int power = int.Parse(input[2]);
            Engine currEngine = new Engine(speed, power);

            int cargoWeight = int.Parse(input[3]);
            string cargoType = input[4];
            Cargo currCargo = new Cargo(cargoWeight, cargoType);

            Car currCar = new Car(currModel,currEngine, currCargo);

            double tyre1Press = double.Parse(input[5]);
            int tyre1Age = int.Parse(input[6]);
            Tire tire1 = new Tire(tyre1Press, tyre1Age);
            currCar.AddTires(tire1);

            double tyre2Press = double.Parse(input[7]);
            int tyre2Age = int.Parse(input[8]);
            Tire tire2 = new Tire(tyre2Press, tyre2Age);
            currCar.AddTires(tire2);

            double tyre3Press = double.Parse(input[9]);
            int tyre3Age = int.Parse(input[10]);
            Tire tire3 = new Tire(tyre3Press, tyre3Age);
            currCar.AddTires(tire3);

            double tyre4Press = double.Parse(input[11]);
            int tyre4Age = int.Parse(input[12]);
            Tire tire4 = new Tire(tyre4Press, tyre4Age);
            currCar.AddTires(tire4);

            cars.Add(currCar);

        }

        string command = Console.ReadLine();

        switch (command.ToLower())
        {
            case "fragile":
                List<Car> fragiles = new List<Car>(cars.Where(x => x.Fragile()));
                 fragiles.ForEach(x => Console.WriteLine(x));
                break;
            case "flammable":
                List<Car> flammables = new List<Car>(cars.Where(x => x.Flammable()));
                flammables.ForEach(x => Console.WriteLine(x));
                break;
            default:
                break;
        }
    }
}