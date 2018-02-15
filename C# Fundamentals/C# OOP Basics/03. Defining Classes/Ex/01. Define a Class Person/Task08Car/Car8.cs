using System;
using System.Collections.Generic;
using System.Text;

public class Car8
{
    public string Model { get; set; }

    public Engine8 Engine { get; set; }

    public Cargo8 Cargo { get; set; }

    public Tire8[] Tires { get; set; } = new Tire8[4];

    public Car8()
    {

    }

    public Car8(string model, Engine8 engine, Cargo8 cargo, Tire8[] tires)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.Tires = tires;
    }
}

