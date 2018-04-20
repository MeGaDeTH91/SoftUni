using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class ProviderControllerTests
{
    private const int RepairValue = 200;

    [Test]
    public void TestRegisterProvider()
    {
        //IProvider provider = new PressureProvider(1, 100);

        IList<string> args = new List<string> { "Pressure", "1", "100" };

        IEnergyRepository energyRepository = new EnergyRepository();

        IProviderController providerController = new ProviderController(energyRepository);

        providerController.Register(args);

        int currentEntitiesCount = ((ProviderController)providerController).Entities.Count;

        const int Expected = 1;

        Assert.That(currentEntitiesCount, Is.EqualTo(Expected));
    }

    [Test]
    public void TestProviderDurabilityDecreaseAndRepair()
    {
        //IProvider provider = new PressureProvider(1, 100);

        IList<string> args = new List<string> { "Pressure", "1", "100" };

        IEnergyRepository energyRepository = new EnergyRepository();

        IProviderController providerController = new ProviderController(energyRepository);

        providerController.Register(args);
        providerController.Produce();
        providerController.Produce();

        double Expected = 500;
        double current = ((Provider)providerController.Entities.First()).Durability;

        Assert.That(current, Is.EqualTo(Expected));

        providerController.Repair(RepairValue);

        Expected = 700;
        current = ((Provider)providerController.Entities.First()).Durability;
        
        Assert.That(current, Is.EqualTo(Expected));
    }

    [Test]
    public void TestEnergyProduced()
    {
        //IProvider provider = new PressureProvider(1, 100);

        IList<string> args = new List<string> { "Pressure", "1", "100" };

        IEnergyRepository energyRepository = new EnergyRepository();

        IProviderController providerController = new ProviderController(energyRepository);

        providerController.Register(args);
        providerController.Produce();
        providerController.Produce();

        double Expected = 400;
        double current = providerController.TotalEnergyProduced;

        Assert.That(current, Is.EqualTo(Expected));
    }

    [Test]
    public void TestIfProviderBrokes()
    {
        //IProvider provider = new PressureProvider(1, 100);

        IList<string> args = new List<string> { "Pressure", "1", "100" };

        IEnergyRepository energyRepository = new EnergyRepository();

        IProviderController providerController = new ProviderController(energyRepository);

        providerController.Register(args);

        for (int i = 0; i < 8; i++)
        {
            providerController.Produce();
        }

        int ExpectedCount = 0;
        int current = providerController.Entities.Count;

        Assert.That(current, Is.EqualTo(ExpectedCount));
    }
}
