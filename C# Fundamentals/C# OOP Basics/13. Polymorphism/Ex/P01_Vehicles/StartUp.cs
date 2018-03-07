using System;
using System.Linq;

namespace P01_Vehicles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(carInput[1]);
            double carFuelConsumption = double.Parse(carInput[2]);
            double carTankCapacity = double.Parse(carInput[3]);
            Vehicle car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);

            string[] truckInput = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInput[1]);
            double truckFuelConsumption = double.Parse(truckInput[2]);
            double truckTankCapacity = double.Parse(truckInput[3]);
            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);

            string[] busInput = Console.ReadLine().Split();
            double busFuelQuantity = double.Parse(busInput[1]);
            double busFuelConsumption = double.Parse(busInput[2]);
            double busTankCapacity = double.Parse(busInput[3]);
            Vehicle bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            Vehicle[] vehicleArr = new Vehicle[3] {car, truck, bus};

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commTokens = Console.ReadLine().Split();

                string commType = commTokens[0];
                string vehicleType = commTokens[1];

                try
                {
                    switch (commType)
                    {
                        case "Drive":
                            double kilometres = double.Parse(commTokens[2]);
                            Console.WriteLine(((Vehicle)vehicleArr.FirstOrDefault(x => x.GetType().ToString() == vehicleType)).Drive(kilometres));
                            break;
                        case "DriveEmpty":
                            double emptyKilometres = double.Parse(commTokens[2]);
                            Console.WriteLine(bus.DriveEmpty(emptyKilometres));
                            break;
                        case "Refuel":
                             double fuelToAdd = double.Parse(commTokens[2]);
                            ((Vehicle)vehicleArr.FirstOrDefault(x => x.GetType().ToString() == vehicleType)).Refuel(fuelToAdd);
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
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
