namespace P07_InfernoInfinity.Factories
{
    using P07_InfernoInfinity.Models.Enums;
    using P07_InfernoInfinity.Models.Gems;
    using System;

    public class GemFactory
    {
        private const string StringNamespace = "P07_InfernoInfinity.Models.Gems";

        public Gem CreateGem(string[] gemArgs)
        {
            string stringGemType = gemArgs[0];
            GemType gemType = Enum.Parse<GemType>(stringGemType);

            string gem = gemArgs[1];
            Type gemTypeOf = Type.GetType($"{StringNamespace}.{gem}");
            var constructorParams = new object[] { gemType };

            Gem gemInstance = (Gem)Activator.CreateInstance(gemTypeOf, constructorParams);

            return gemInstance;
        }
    }
}
