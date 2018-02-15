using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Speed_Racing
{
    class Car
    {
        public string Model { get; set; }
        public decimal FuelAmount { get; set; }
        public decimal FuelConsumption { get; set; }
        public decimal TravelDistance { get; set; }

        public Car(string model, decimal fuelAm, decimal fuelConsum)
        {
            this.Model = model;
            this.FuelAmount = fuelAm;
            this.FuelConsumption = fuelConsum;
            this.TravelDistance = 0;
        }

        public bool Drive(decimal distance)
            
        {
            decimal neededFuel = this.FuelConsumption * distance;
            if(this.FuelAmount - neededFuel >= 0)
            {
                this.FuelAmount -= neededFuel;
                this.TravelDistance += distance;
                return true;
            }
            else
            {
               
                return false;
            }
            
        }
    }
}
