﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Dog : Animal
{
    public Dog(string name, int age, string gender)
        :base(name,age,gender)
    {

    }

    public override string ProduceSound()
    {
        return "Woof!";
    }

    //public override string ToString()
    //{
    //    return $"Dog" + Environment.NewLine +
    //           $"{this.Name} {this.Age} {this.Gender}" + Environment.NewLine +
    //           $"{this.ProduceSound()}";
    //}
}