namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Contracts;
	using Entities.Contracts;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            Assembly assembly = Assembly.GetCallingAssembly();

            Type instrumentType = assembly.GetTypes()
                .FirstOrDefault(x => x.Name == type);

            object[] constructorParams = new object[] { };

            IInstrument instrument = (IInstrument)Activator.CreateInstance(instrumentType, constructorParams);

            return instrument;
		}
	}
}