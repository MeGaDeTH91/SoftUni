using System;

public class PoisonPotion : Item
{
    private const int Initial_Potion_Weight = 5;

    public  PoisonPotion() : base(Initial_Potion_Weight)
    {
    }

    public override void AffectCharacter(Character character)
    {
        base.AffectCharacter(character);
        character.PosionPotionHpDecrease(20);
    }
}
