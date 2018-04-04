namespace P07_InfernoInfinity.Models.Gems
{
    using P07_InfernoInfinity.Models.Enums;
    using System;

    public abstract class Gem
    {
        private int strength;
        private int agility;
        private int vitality;
        private GemType gemType;
        
        public Gem(GemType gemType, int strength, int agility, int vitality)
        {
            this.GemType = gemType;
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitality;
        }

        protected void IncreaseBonusPoints()
        {
            this.Strength += (int)this.GemType;
            this.Agility += (int)this.GemType;
            this.Vitality += (int)this.GemType;
        }

        public GemType GemType
        {
            get { return this.gemType; }
            private set { this.gemType = value; }
        }

        public int Strength
        {
            get { return this.strength; }
            private set { this.strength = value; }
        }

        public int Agility
        {
            get { return this.agility; }
            private set { this.agility = value; }
        }

        public int Vitality
        {
            get { return this.vitality; }
            private set { this.vitality = value; }
        }
    }
}
