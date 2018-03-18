using System;

public class CharacterFactory
{
    public Character CreateCharacter(string stringFaction, string charType, string name)
    {
        Faction faction;
        bool factionIsValid = Enum.TryParse<Faction>(stringFaction, out faction);
        if (!factionIsValid)
        {
            throw new ArgumentException($"Invalid faction \"{stringFaction}\"!");
        }

        if (charType.Equals("Warrior"))
        {
            return new Warrior(name, faction);
        }
        else if (charType.Equals("Cleric"))
        {
            return new Cleric(name, faction);
        }
        else
        {
            throw new ArgumentException($"Invalid character type \"{charType}\"!");
        } 
    }
}
