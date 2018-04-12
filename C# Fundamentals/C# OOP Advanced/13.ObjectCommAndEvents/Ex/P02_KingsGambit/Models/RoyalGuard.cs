namespace P02_KingsGambit.Models
{
    using System;

    public class RoyalGuard : AbstractMan
    {
        public RoyalGuard(string name) : base(name)
        {
        }

        public override void OnKingAttack()
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
