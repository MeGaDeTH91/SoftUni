using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> Harvesters;
    private List<Provider> Providers;
    private double TotalEnergyStored;
    private double TotalMinedOre;
    private string mode;
    private HarvesterFactory HarvesterFactory;
    private ProviderFactory ProviderFactory;

    public DraftManager()
    {
        this.Harvesters = new List<Harvester>();
        this.Providers = new List<Provider>();
        this.mode = "Full";
        this.HarvesterFactory = new HarvesterFactory();
        this.ProviderFactory = new ProviderFactory();
    }
    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            this.Harvesters.Add(this.HarvesterFactory.RegisterHarvester(arguments));
        }
        catch (Exception e)
        {
            return e.Message;
        }
        

        string type = arguments[0];
        string id = arguments[1];

        return $"Successfully registered {type} Harvester - {id}";
    }
    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            this.Providers.Add(this.ProviderFactory.RegisterProvider(arguments));
        }
        catch (Exception e)
        {
            return e.Message;
        }
        
        string type = arguments[0];
        string id = arguments[1];

        return $"Successfully registered {type} Provider - {id}";
    }
    public string Day()
    {
        double summedEnergyOutput = this.Providers.Sum(x => x.EnergyOutput);
        this.TotalEnergyStored += summedEnergyOutput;
        
        double summedOreOutput = 0.0d;

        if(this.mode != "Energy")
        {
            double harvestersNeededEnergy = this.Harvesters.Sum(x => x.EnergyRequirement);

            switch (this.mode)
            {
                case "Full":
                    summedOreOutput = this.Harvesters.Sum(x => x.OreOutput);
                    break;
                case "Half":
                    harvestersNeededEnergy = this.Harvesters.Sum(x => x.EnergyRequirement) * (60.0d / 100.0d);
                    summedOreOutput = this.Harvesters.Sum(x => x.OreOutput) * (50.0d / 100.0d);
                    break;
                default:
                    break;
            }

            if(this.TotalEnergyStored >= harvestersNeededEnergy)
            {
                this.TotalEnergyStored -= harvestersNeededEnergy;
                this.TotalMinedOre += summedOreOutput;
            }
            else
            {
                summedOreOutput = 0.0d;
            }
        }
        
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"A day has passed.");
        sb.AppendLine($"Energy Provided: {summedEnergyOutput}");
        sb.AppendLine($"Plumbus Ore Mined: {summedOreOutput}");

        return sb.ToString().Trim();
    }
    public string Mode(List<string> arguments)
    {
        string currentMode = arguments[0];
        this.mode = currentMode;

        return $"Successfully changed working mode to {currentMode} Mode";
    }
    public string Check(List<string> arguments)
    {
        string currentId = arguments[0];

        var provider = this.Providers.FirstOrDefault(x => x.Id == currentId);
        var harvester = this.Harvesters.FirstOrDefault(x => x.Id == currentId);

        if(provider == null && harvester == null)
        {
            return $"No element found with id - {currentId}";
        }
        else if(provider == null)
        {
            return harvester.ToString();
        }
        else
        {
            return provider.ToString();
        }
    }
    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"System Shutdown");
        sb.AppendLine($"Total Energy Stored: {TotalEnergyStored}");
        sb.AppendLine($"Total Mined Plumbus Ore: {TotalMinedOre}");

        return sb.ToString().Trim();
    }

}
