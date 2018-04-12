namespace P02_KingsGambit.Models
{
    using System;

    public class Footman : AbstractMan
    {
        public Footman(string name) : base(name)
        {
        }

        public override void OnKingAttack()
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
