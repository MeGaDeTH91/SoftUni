using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Kitten : Cat
{
    public Kitten(string name, int age, string gender)
        :base(name,age, gender)
    {
        this.Gender = "Female";
    }

    public override string ProduceSound()
    {
        return "Meow";
    }

    //public override string ToString()
    //{
    //    return $"Kitten" + Environment.NewLine +
    //           $"{this.Name} {this.Age} {this.Gender}" + Environment.NewLine +
    //           $"{this.ProduceSound()}";
    //}
}
