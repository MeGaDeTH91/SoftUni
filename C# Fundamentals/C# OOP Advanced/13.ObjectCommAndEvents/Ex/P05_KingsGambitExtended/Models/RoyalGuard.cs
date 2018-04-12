namespace P02_KingsGambit.Models
{
    using System;

    public class RoyalGuard : AbstractMan
    {
        private const int RoyalGuardHitCounts = 3;

        public RoyalGuard(string name) : base(name)
        {
            this.HitTimesToDeath = RoyalGuardHitCounts;
        }

        public override void OnKingAttack()
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
