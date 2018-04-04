namespace P07_InfernoInfinity.Factories
{
    using P07_InfernoInfinity.Models.Enums;
    using P07_InfernoInfinity.Models.Weapons;
    using System;

    public class WeaponFactory
    {
        private const string StringNamespace = "P07_InfernoInfinity.Models.Weapons";

        public Weapon CreateWeapon(string rarity, string weaponType, string weaponName)
        {
            RarityType rarityType = Enum.Parse<RarityType>(rarity);

            Type currentType = Type.GetType($"{StringNamespace}.{weaponType}");

            var constructorParams = new object[] {weaponName, rarityType };
            Weapon classInstance = (Weapon)Activator.CreateInstance(currentType, constructorParams);

            return classInstance;
        }
    }
}
