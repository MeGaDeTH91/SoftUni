namespace P02_KingsGambit.Models
{
    using System;
    using System.Collections.Generic;

    public delegate void KingIsUnderAttack();

    public class Kingman : AbstractMan
    {
        public event KingIsUnderAttack KingIsDefinitelyUnderAttack;

        public Kingman(string name) : base(name)
        {
        }

        public override void OnKingAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            KingIsDefinitelyUnderAttack?.Invoke();
        }
    }
}
