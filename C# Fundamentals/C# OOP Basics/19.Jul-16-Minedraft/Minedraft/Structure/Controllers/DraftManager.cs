using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.mode = "Full";
        harvesterFactory = new HarvesterFactory();
        providerFactory = new ProviderFactory();
    }

    public string RegisterHarvester(List<string> arguments)
    {//Защо Try-Catch тук?
        try
        {
            this.harvesters.Add(this.harvesterFactory.RegisterHarvester(arguments));
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }

        var type = arguments[0];
        var id = arguments[1];

        return $"Successfully registered {type} Harvester - {id}";
    }
    public string RegisterProvider(List<string> arguments)
    {//Защо Try-Catch тук?
        try
        {
            this.providers.Add(this.providerFactory.RegisterProvider(arguments));
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
        StringBuilder sb = new StringBuilder();

        double summedEnergyOutput = this.providers.Sum(x => x.EnergyOutput);
        this.totalStoredEnergy += summedEnergyOutput;

        double summedOreOutput = 0.0d;

        switch (this.mode)
        {
            case "Full":
                double neededFullEnergy = this.harvesters.Sum(x => x.EnergyRequirement);
                if (!CheckEnergy(neededFullEnergy))
                {
                    break;
                }
                summedOreOutput = this.harvesters.Sum(x => x.OreOutput);
                this.totalMinedOre += summedOreOutput;
                this.totalStoredEnergy -= this.harvesters.Sum(x => x.EnergyRequirement);
                break;
            case "Half":
                double halfConsumedEnergy = this.harvesters.Sum(x => x.EnergyRequirement) * (60.0d / 100.0d);
                if (!CheckEnergy(halfConsumedEnergy))
                {
                    break;
                }

                summedOreOutput = this.harvesters.Sum(x => x.OreOutput) * (50.0d / 100.0d);

                this.totalStoredEnergy -= halfConsumedEnergy;
                this.totalMinedOre += summedOreOutput;
                break;
            default:
                break;
        }
        

        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {summedEnergyOutput}");
        sb.AppendLine($"Plumbus Ore Mined: {summedOreOutput}");
        return sb.ToString().Trim();
    }

    private bool CheckEnergy(double neededFullEnergy)
    {
        if (this.totalStoredEnergy >= neededFullEnergy)
        {
            return true;
        }
        return false;
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

        var harvester = this.harvesters.FirstOrDefault(x => x.Id == currentId);
        var provider = this.providers.FirstOrDefault(x => x.Id == currentId);
        
        if(harvester == null && provider == null)
        {
            return $"No element found with id - {currentId}";
        }
        else if(harvester == null)
        {
            return provider.ToString();
        }
        else
        {
            return harvester.ToString();
        }
    }
    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {totalStoredEnergy}");
        sb.AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");

        return sb.ToString().Trim();
    }


}
