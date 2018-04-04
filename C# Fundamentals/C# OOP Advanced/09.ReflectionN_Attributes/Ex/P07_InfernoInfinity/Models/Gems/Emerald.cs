namespace P07_InfernoInfinity.Models.Gems
{
    using P07_InfernoInfinity.Models.Enums;

    public class Emerald : Gem
    {
        private const int InitialStrength = 1;
        private const int InitialAgility = 4;
        private const int InitialVitality = 9;

        public Emerald(GemType gemType) : base(gemType, InitialStrength, InitialAgility, InitialVitality)
        {
            this.IncreaseBonusPoints();
        }
    }
}
