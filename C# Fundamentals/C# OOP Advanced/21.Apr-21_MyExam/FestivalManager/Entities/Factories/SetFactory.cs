namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
	using Entities.Contracts;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            Assembly assembly = Assembly.GetCallingAssembly();

            Type setType = assembly.GetTypes()
                .FirstOrDefault(x => x.Name == type);

            object[] constructorParams = new object[] { name };

            ISet set = (ISet)Activator.CreateInstance(setType, constructorParams);

            return set;
        }
	}
}
