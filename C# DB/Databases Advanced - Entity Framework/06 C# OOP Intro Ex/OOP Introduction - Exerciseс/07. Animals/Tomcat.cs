using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Tomcat : Cat
{
    public Tomcat(string name, int age, string gender)
        :base(name,age, gender)
    {
        this.Gender = "Male";
    }

    public override string ProduceSound()
    {
        return "MEOW";
    }

    //public override string ToString()
    //{
    //    return $"Tomcat" + Environment.NewLine +
    //           $"{this.Name} {this.Age} {this.Gender}" + Environment.NewLine +
    //           $"{this.ProduceSound()}";
    //}
}