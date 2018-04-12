namespace P02_KingsGambit.Models
{
    using System;

    public class Footman : AbstractMan
    {
        private const int FootmanHitCounts = 2;

        public Footman(string name) : base(name)
        {
            this.HitTimesToDeath = FootmanHitCounts;
        }

        public override void OnKingAttack()
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
