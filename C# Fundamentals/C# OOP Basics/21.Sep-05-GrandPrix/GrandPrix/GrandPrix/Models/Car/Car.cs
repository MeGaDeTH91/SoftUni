using System;
using System.Collections.Generic;

public class Car
{
    private TyreFactory tyreFactory = new TyreFactory();

    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public void ReduceFuel(int trackLength, double fuelConsumption)
    {
        this.FuelAmount -= trackLength * fuelConsumption;
    }

    public void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    public void ChangeTyre(List<string> arguments)
    {
        this.Tyre = tyreFactory.AddTyre(arguments);
    }

    public Tyre Tyre
    {
        get { return tyre; }
        protected set
        {
            tyre = value;
        }
    }


    public double FuelAmount
    {
        get { return fuelAmount; }
        protected set
        {
            if (value > 160)
            {
                value = 160;
            }
            else if(value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            fuelAmount = value;
        }
    }


    public int Hp
    {
        get { return hp; }
        protected set { hp = value; }
    }

}
