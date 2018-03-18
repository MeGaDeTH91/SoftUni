using System;

public class HealthPotion : Item
{
    private const int Initial_Potion_Weight = 5;

    public HealthPotion() : base(Initial_Potion_Weight)
    {
    }

    public override void AffectCharacter(Character character)
    {
        base.AffectCharacter(character);
        character.HealthPotionHpIncrease(20);
    }
}
