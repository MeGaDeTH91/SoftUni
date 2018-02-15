using System;
using System.Collections.Generic;
using System.Text;

public class Engine10
{
    public string Model { get; set; }
    public string Power { get; set; }
    public string Displacement { get; set; }
    public string Efficiency { get; set; }

    public override string ToString()
    {
        string currDispl = this.Displacement != null ? this.Displacement: "n/a";
        string currEff = this.Efficiency != null ? this.Efficiency : "n/a";
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"  {this.Model}:");
        sb.AppendLine($"    Power: {this.Power}");
        sb.AppendLine($"    Displacement: {currDispl}");
        sb.AppendLine($"    Efficiency: {currEff}");
        return sb.ToString().TrimEnd();
    }
}

