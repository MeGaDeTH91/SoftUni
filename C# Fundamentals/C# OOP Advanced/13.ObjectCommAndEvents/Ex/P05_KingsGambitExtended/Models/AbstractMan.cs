namespace P02_KingsGambit.Models
{
    using System;

    public abstract class AbstractMan
    {
        private string name;

        public int HitTimesToDeath;

        public AbstractMan(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public abstract void OnKingAttack();
    }
}
