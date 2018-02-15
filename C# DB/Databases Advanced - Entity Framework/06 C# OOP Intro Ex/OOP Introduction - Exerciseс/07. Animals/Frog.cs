using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Frog : Animal
{
    public Frog(string name, int age, string gender)
        :base(name,age,gender)
    {

    }

    public override string ProduceSound()
    {
        return "Ribbit";
    }

    //public override string ToString()
    //{
    //    return $"Frog" + Environment.NewLine +
    //           $"{this.Name} {this.Age} {this.Gender}" + Environment.NewLine +
    //           $"{this.ProduceSound()}";
    //}
}