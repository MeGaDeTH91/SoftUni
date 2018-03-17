using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private List<Nation> allNations;
    private AirNation airNation;
    private EarthNation earthNation;
    private FireNation fireNation;
    private WaterNation waterNation;
    private StringBuilder warRecord;
    private BenderFactory benderFactory;
    private MonumentFactory monumentFactory;
    private int warNumber;

    public NationsBuilder()
    {
        this.airNation = new AirNation();
        this.earthNation = new EarthNation();
        this.fireNation = new FireNation();
        this.waterNation = new WaterNation();
        this.allNations = new List<Nation>() { airNation, earthNation, fireNation, waterNation};
        this.warRecord = new StringBuilder();
        this.benderFactory = new BenderFactory();
        this.monumentFactory = new MonumentFactory();
        this.warNumber = 1;
    }

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        switch (type)
        {
            case "Air":
                this.airNation.AddBender(this.benderFactory.AssignBender(benderArgs));
                break;
            case "Fire":
                this.fireNation.AddBender(this.benderFactory.AssignBender(benderArgs));
                break;
            case "Earth":
                this.earthNation.AddBender(this.benderFactory.AssignBender(benderArgs));
                break;
            case "Water":
                this.waterNation.AddBender(this.benderFactory.AssignBender(benderArgs));
                break;
            default:
                break;
        }
         
    }
    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        switch (type)
        {
            case "Air":
                this.airNation.AddMonument(this.monumentFactory.AssignMonument(monumentArgs));
                break;
            case "Fire":
                this.fireNation.AddMonument(this.monumentFactory.AssignMonument(monumentArgs));
                break;
            case "Earth":
                this.earthNation.AddMonument(this.monumentFactory.AssignMonument(monumentArgs));
                break;
            case "Water":
                this.waterNation.AddMonument(this.monumentFactory.AssignMonument(monumentArgs));
                break;
            default:
                break;
        }
    }
    public string GetStatus(string nationsType)
    {
        switch (nationsType)
        {
            case "Air":
                return this.airNation.ToString();
            case "Fire":
                return this.fireNation.ToString();
            case "Earth":
                return this.earthNation.ToString();
            case "Water":
                return this.waterNation.ToString();
            default:
                return string.Empty;
        }
    }
    public void IssueWar(string nationsType)
    {
        warRecord.AppendLine($"War {this.warNumber} issued by {nationsType}");
        this.warNumber++;

        foreach (var nation in this.allNations.OrderByDescending(x => x.TotalPower).Skip(1))
        {
            nation.DestroyThisNationInTheNameOfMiddleEarth();
        }
    }
    public string GetWarsRecord()
    {
        return this.warRecord.ToString().Trim();
    }

}
