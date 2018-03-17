using System;
using System.Collections.Generic;
using System.Linq;

public class Garage
{
    private List<Car> parkedCars;
    public int NumberOfParkedCars => this.parkedCars.Count;

    public Garage()
    {
        this.parkedCars = new List<Car>();
    }
    public void ParkCarInGarage(Car car)
    {
        if (!this.ParkedCars.Contains(car))
        {
            this.parkedCars.Add(car);
        }
        else
        {
            throw new ArgumentException();
        }
        
    }
    public void UnparkCarInGarage(Car car)
    {
        this.parkedCars.Remove(car);
    }

    public List<Car> ParkedCars
    {
        get
        {
            return this.parkedCars;
        }
        protected set
        {
            this.parkedCars = value;
        }
    }
}
