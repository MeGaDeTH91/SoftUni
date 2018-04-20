using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string type, double scoreToComplete)
    {
        Type missionType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == type);

        object[] constructorParams = new object[] { scoreToComplete };

        IMission mission = (IMission)Activator.CreateInstance(missionType, constructorParams);

        return mission;
    }
}
