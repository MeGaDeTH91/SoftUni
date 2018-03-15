using System;
using System.Text;

public abstract class Provider : Identificator
{
    //private string id;
    private double energyOutput;

    //public Provider(string id, double energyOutput)
    //{
    //    this.Id = id;
    //    this.EnergyOutput = energyOutput;
    //}

    protected Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    //public string Id
    //{
    //    get { return this.id; }
    //    set { this.id = value; }
    //}
    public virtual double EnergyOutput
    {
        get
        {
            return this.energyOutput;
        }
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's EnergyOutput");
            }
            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        string currentTypeFull = this.GetType().Name;
        string currentType = currentTypeFull.Substring(0, currentTypeFull.IndexOf("Provider"));

        sb.AppendLine($"{currentType} Provider - {this.Id}");
        sb.AppendLine($"Energy Output: {this.EnergyOutput}");
        return sb.ToString().Trim();
    }
}
