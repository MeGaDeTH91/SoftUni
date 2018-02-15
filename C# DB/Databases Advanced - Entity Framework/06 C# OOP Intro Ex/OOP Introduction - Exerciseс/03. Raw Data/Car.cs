using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Car
{
    public string Model;
    public Engine Engine;
    public Cargo Cargo;
    public List<Tire> tires = new List<Tire>();

    public Car()
    {

    }

    public Car(string model, Engine engine, Cargo cargo)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
    }

    public Car(string model, Engine engine, Cargo cargo, List<Tire> tiress)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.Tires = new List<Tire>(tiress);
    }

    public void AddTires(Tire tire)
    {
        if(this.Tires.Count < 4)
        {
            this.Tires.Add(tire);
        }
        
    }

    public bool Fragile()
    {
        return (this.tires.Any(x=> x.Pressure < 1) && this.Cargo.Type == "fragile");
    }

    public bool Flammable()
    {
        return (this.Engine.Power > 250 && this.Cargo.Type == "flammable");
    }

    public List<Tire> Tires
    {
        get
        {
            return this.tires;
        }
        set
        {
            if(value.Count == 4)
            {
                this.tires = value;
            }
        }
    }

    public override string ToString()
    {
        return $"{this.Model}";
    }
}