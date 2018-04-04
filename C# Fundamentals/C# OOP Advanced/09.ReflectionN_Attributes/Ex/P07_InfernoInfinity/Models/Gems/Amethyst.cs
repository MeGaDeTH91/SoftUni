namespace P07_InfernoInfinity.Models.Gems
{
    using P07_InfernoInfinity.Models.Enums;

    public class Amethyst : Gem
    {
        private const int InitialStrength = 2;
        private const int InitialAgility = 8;
        private const int InitialVitality = 4;

        public Amethyst(GemType gemType) : base(gemType, InitialStrength, InitialAgility, InitialVitality)
        {
            this.IncreaseBonusPoints();
        }
    }
}
