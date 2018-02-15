using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Cargo
{
    public int Weight;
    public string Type;

    public Cargo()
    {

    }

    public Cargo(int weight, string type)
    {
        this.Weight = weight;
        this.Type = type;
    }
}