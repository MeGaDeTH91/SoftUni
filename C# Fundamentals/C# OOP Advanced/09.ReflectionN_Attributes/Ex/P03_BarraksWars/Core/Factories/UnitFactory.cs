namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        private const string stringNamespace = "_03BarracksFactory.Models.Units";

        public IUnit CreateUnit(string unitType)
        {
            Type classType = Type.GetType($"{stringNamespace}.{unitType}");

            if (classType == null)
            {
                return null;
            }

            var unit = Activator.CreateInstance(classType, true);

            return (IUnit)unit;
        }
    }
}
