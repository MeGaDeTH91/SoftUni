using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

public class ProviderControllerTests
{
    

    //private string[] harvesterArguments = new string[] { "Hammer", "20", "100", "100" };

    [Test]
    public void TestRegister()
    {
         IList<string> providerArguments = new List<string> { "Pressure", "40", "100" };
         IEnergyRepository energyRepository = new EnergyRepository();

        IProviderController providerController = new ProviderController(energyRepository);

        providerController.Register(providerArguments);

        int actual = providerController.Entities.Count;
        int expected = 1;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestTotalEnergy()
    {
        IList<string> providerArguments = new List<string> { "Pressure", "40", "100" };
        IEnergyRepository energyRepository = new EnergyRepository();

        IProviderController providerController = new ProviderController(energyRepository);

        providerController.Register(providerArguments);

        providerController.Produce();

        double actual = providerController.TotalEnergyProduced;
        double expected = 200;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestBroke()
    {
        IList<string> providerArguments = new List<string> { "Pressure", "40", "100" };
        IEnergyRepository energyRepository = new EnergyRepository();

        IProviderController providerController = new ProviderController(energyRepository);

        providerController.Register(providerArguments);

        for (int i = 0; i < 8; i++)
        {
            providerController.Produce();
        }
        

        int actual = providerController.Entities.Count;
        int expected = 0;

        Assert.That(actual, Is.EqualTo(expected));
    }
}
