using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string name)
    {
        Type ammoType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == name);

        object[] constructorParams = new object[] { name };

        IAmmunition ammunition = (IAmmunition)Activator.CreateInstance(ammoType, constructorParams);

        return ammunition;
    }
}