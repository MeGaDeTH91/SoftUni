using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private string mode;
    private List<IHarvester> harvesters;
    private IHarvesterFactory harvesterFactory;
    private IEnergyRepository energyRepository;

    private const int halfModeMultiplier = 50;
    private const int energyModeMultiplier = 20;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.harvesters = new List<IHarvester>();
        this.harvesterFactory = new HarvesterFactory();
        this.mode = Constants.DefaultHarvesterMode;
        this.energyRepository = energyRepository;
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string ChangeMode(string mode)
    {
        this.mode = mode;

        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception ex)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChangeSuccess, mode);
    }

    public string Produce()
    {
        double todayOreProduction = this.harvesters.Sum(x => x.OreOutput);
        double harvestersNeededEnergyToStart = this.harvesters.Sum(x => x.EnergyRequirement);

        switch (this.mode)
        {
            case Constants.HalfHarvesterMode:
                todayOreProduction *= (halfModeMultiplier / 100.0d);
                harvestersNeededEnergyToStart *= (halfModeMultiplier / 100.0d);
                break;
            case Constants.EnergyHarvesterMode:
                todayOreProduction *= (energyModeMultiplier / 100.0d);
                harvestersNeededEnergyToStart *= (energyModeMultiplier / 100.0d);
                break;
            default:
                break;
        }

        if (this.energyRepository.TakeEnergy(harvestersNeededEnergyToStart))
        {
            this.OreProduced += todayOreProduction;
        }
        else
        {
            todayOreProduction = 0;
        }
        
        return string.Format(Constants.OreOutputToday, todayOreProduction);
    }

    public string Register(IList<string> args)
    {
        IHarvester harvester = this.harvesterFactory.GenerateHarvester(args);

        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistrationOfMachine, harvester.GetType().Name);
    }
}
