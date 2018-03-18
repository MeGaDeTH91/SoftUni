using System;

public class Cleric : Character, IHealable
{
    private const double Cleric_Base_Health = 50.0d;
    private const double Cleric_Base_Armor = 25.0d;
    private const double Cleric_Base_AbilityPoints = 40.0d;
    private const double Initial_RestHealMultiplier = 0.5d;

    public Cleric(string name, Faction faction) : base(name, Cleric_Base_Health, Cleric_Base_Armor, Cleric_Base_AbilityPoints, new Backpack(), faction)
    {
        this.RestHealMultiplier = Initial_RestHealMultiplier;
    }

    public void Heal(Character character)
    {
        if (!this.IsAlive || !character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
        if(this.Faction != character.Faction)
        {
            throw new InvalidOperationException("Cannot heal enemy character!");
        }
        character.GetHealedByCleric(this.AbilityPoints);
    }
}
