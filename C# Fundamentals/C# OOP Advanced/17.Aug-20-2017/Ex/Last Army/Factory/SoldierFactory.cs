using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string type, string name, int age, double experience, double endurance)
    {
        object[] constructorParams = new object[] { name, age, experience, endurance };

        Type soldierType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == type);

        ISoldier soldier = (ISoldier)Activator.CreateInstance(soldierType, constructorParams);

        return soldier;
    }
}