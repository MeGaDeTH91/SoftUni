﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Cat : Animal
{
    public Cat(string name, int age, string gender)
        :base(name,age,gender)
    {

    }

    public override string ProduceSound()
    {
        return "Meow meow";
    }

    //public override string ToString()
    //{
    //    return $"Cat" + Environment.NewLine +
    //           $"{this.Name} {this.Age} {this.Gender}" + Environment.NewLine +
    //           $"{this.ProduceSound()}";
    //}
}