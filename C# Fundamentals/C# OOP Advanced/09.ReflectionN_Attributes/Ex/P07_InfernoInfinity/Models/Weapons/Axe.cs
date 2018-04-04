namespace P07_InfernoInfinity.Models.Weapons
{
    using P07_InfernoInfinity.Models.Enums;

    public class Axe : Weapon
    {
        private const int InitialMinDamage = 5;
        private const int InitialMaxDamage = 10;
        private const int InitialSockets = 4;

        public Axe(string name, RarityType rarity) : base(name, rarity, InitialMinDamage, InitialMaxDamage, InitialSockets)
        {
            this.IncreaseDamage();
        }
    }
}
