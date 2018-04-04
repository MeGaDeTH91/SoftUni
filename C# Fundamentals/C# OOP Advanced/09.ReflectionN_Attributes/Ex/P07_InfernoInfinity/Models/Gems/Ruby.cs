namespace P07_InfernoInfinity.Models.Gems
{
    using System;
    using P07_InfernoInfinity.Models.Enums;

    public class Ruby : Gem
    {
        private const int InitialStrength = 7;
        private const int InitialAgility = 2;
        private const int InitialVitality = 5;

        public Ruby(GemType gemType) : base(gemType, InitialStrength, InitialAgility, InitialVitality)
        {
            this.IncreaseBonusPoints();
        }
    }
}
