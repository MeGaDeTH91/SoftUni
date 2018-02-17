using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Tire
    {
        public double Pressure { get; set; }
        public int Age { get; set; }

        public Tire(double press, int age)
        {
            this.Pressure = press;
            this.Age = age;
        }
        public Tire()
        {

        }
    }
}
