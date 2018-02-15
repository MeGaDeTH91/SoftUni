using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Tire
{
    public double Pressure;
    public int Age;

    public Tire()
    {

    }

    public Tire(double pressure, int age)
    {
        this.Pressure = pressure;
        this.Age = age;
    }
}