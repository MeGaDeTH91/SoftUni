using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private const double EnergyModeMultiPlier = 20.0d;
    private const double HalfModeMultiPlier = 50.0d;

    private IEnergyRepository energyRepository;
    private HarvesterModeType harvesterMode;
    private List<IHarvester> harvesters;
    private IHarvesterFactory harvesterFactory;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();
        this.TotalOreProduced = Constants.InitialOreQuantity;
        this.harvesterFactory = new HarvesterFactory();
    }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public double TotalOreProduced { get; private set; }

    public string ChangeMode(string mode)
    {
        HarvesterModeType harvesterNewMode;
        bool IsValidMode = Enum.TryParse(mode, out harvesterNewMode);

        List<IHarvester> reminder = new List<IHarvester>();

        if (IsValidMode)
        {
            this.harvesterMode = harvesterNewMode;

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
        }
        return string.Format(Constants.ModeChangeMessage, mode);
    }

    public string Produce()
    {
        double harvesterTotalEnergyRequired = this.harvesters.Sum(x => x.EnergyRequirement);
        double harvesterTotalOreProduction = this.harvesters.Sum(x => x.OreOutput);

        switch (this.harvesterMode)
        {
            case HarvesterModeType.Energy:
                harvesterTotalEnergyRequired *= (EnergyModeMultiPlier / 100.0d);
                harvesterTotalOreProduction *= (EnergyModeMultiPlier / 100.0d);
                break;
            case HarvesterModeType.Half:
                harvesterTotalEnergyRequired *= (HalfModeMultiPlier / 100.0d);
                harvesterTotalOreProduction *= (HalfModeMultiPlier / 100.0d);
                break;
            default:
                break;
        }

        if(this.energyRepository.TakeEnergy(harvesterTotalEnergyRequired))
        {
            this.TotalOreProduced += harvesterTotalOreProduction;
        }
        else
        {
            harvesterTotalOreProduction = 0.0d;
        }

        return string.Format(Constants.OreOutputToday, harvesterTotalOreProduction);
    }

    public string Register(IList<string> args)
    {
        IHarvester harvester = this.harvesterFactory.GenerateHarvester(args);

        this.harvesters.Add(harvester);

        string harvesterType = harvester.GetType().Name;

        return string.Format(Constants.SuccessfullRegistration, harvesterType);
    }
}
