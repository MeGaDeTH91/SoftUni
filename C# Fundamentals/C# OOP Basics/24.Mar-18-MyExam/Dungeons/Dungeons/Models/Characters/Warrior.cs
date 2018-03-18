using System;

public class Warrior : Character, IAttackable
{
    private const double Warrior_Base_Health = 100.0d;
    private const double Warrior_Base_Armor = 50.0d;
    private const double Warrior_Base_AbilityPoints = 40.0d;

    public Warrior(string name, Faction faction) : base(name, Warrior_Base_Health, Warrior_Base_Armor, Warrior_Base_AbilityPoints, new Satchel(), faction)
    {
    }

    public void Attack(Character character)
    {
        if (this == character)
        {
            throw new InvalidOperationException("Cannot attack self!");
        }
        if (!this.IsAlive || !character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
        
        if(this.Faction == character.Faction)
        {
            throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
        }
        character.TakeDamage(this.AbilityPoints);
    }
}
