namespace P07_InfernoInfinity.Models.Weapons
{
    using P07_InfernoInfinity.Models.Enums;

    public class Sword : Weapon
    {
        private const int InitialMinDamage = 4;
        private const int InitialMaxDamage = 6;
        private const int InitialSockets = 3;

        public Sword(string name, RarityType rarity) : base(name, rarity, InitialMinDamage, InitialMaxDamage, InitialSockets)
        {
            this.IncreaseDamage();
        }
    }
}
