namespace P07_InfernoInfinity.Models.Weapons
{
    using P07_InfernoInfinity.Models.Enums;

    public class Knife : Weapon
    {
        private const int InitialMinDamage = 3;
        private const int InitialMaxDamage = 4;
        private const int InitialSockets = 2;

        public Knife(string name, RarityType rarity) : base(name, rarity, InitialMinDamage, InitialMaxDamage, InitialSockets)
        {
            this.IncreaseDamage();
        }
    }
}
