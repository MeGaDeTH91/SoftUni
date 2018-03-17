using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public double TotalPower
    {
        get
        {
            if(this.monuments.Count > 0)
            {
                double benderSum = this.benders.Sum(x => x.TotalPower);
                double bonus = this.monuments.Sum(x => x.Affinity);
                return benderSum + ( benderSum * (bonus / 100.0d));
            }
            else
            {
                return this.benders.Sum(x => x.TotalPower);
            }
        }
    }

    protected Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public void AddBender(Bender bender)
    {
        this.benders.Add(bender);
    }
    public void AddMonument(Monument monument)
    {
        this.monuments.Add(monument);
    }
    public void DestroyThisNationInTheNameOfMiddleEarth()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        string fullType = this.GetType().Name;
        string type = fullType.Substring(0, fullType.IndexOf("Nation"));
        sb.AppendLine($"{type} Nation");
        if(this.benders.Count == 0)
        {
            sb.AppendLine("Benders: None");
        }
        else
        {
            sb.AppendLine("Benders:");
            foreach (var bender in this.benders)
            {
                sb.AppendLine($"###{bender.ToString()}");
            }
        }
        if (this.monuments.Count == 0)
        {
            sb.AppendLine("Monuments: None");
        }
        else
        {
            sb.AppendLine("Monuments:");
            foreach (var monument in this.monuments)
            {
                sb.AppendLine($"###{monument.ToString()}");
            }
        }

        return sb.ToString().Trim();
    }
}
