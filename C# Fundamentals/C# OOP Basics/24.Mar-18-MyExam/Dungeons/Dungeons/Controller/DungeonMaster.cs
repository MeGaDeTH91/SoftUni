using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DungeonMaster
{
    private List<Character> characters;
    private CharacterFactory characterFactory;
    private ItemFactory itemFactory;
    private Stack<Item> pool;
    private int IncrementSurvivorRounds = 0;

    public DungeonMaster()
    {
        this.characterFactory = new CharacterFactory();
        this.itemFactory = new ItemFactory();
        this.pool = new Stack<Item>();
        this.characters = new List<Character>();
    }

    public string JoinParty(string[] args)
    {
        string stringFaction = args[0];
        string charType = args[1];
        string name = args[2];
        Faction faction;
        bool factionIsValid = Enum.TryParse<Faction>(stringFaction, out faction);
        if (!factionIsValid)
        {
            throw new ArgumentException($"Invalid faction \"{stringFaction}\"!");
        }
        if (!charType.Equals("Warrior") && !charType.Equals("Cleric"))
        {
            throw new ArgumentException($"Invalid character type \"{charType}\"!");
        }

            this.characters.Add(this.characterFactory.CreateCharacter(stringFaction, charType, name));
        return $"{name} joined the party!";
    }

    public string AddItemToPool(string[] args)
    {
        string itemType = args[0];

        if (!itemType.Equals("PoisonPotion") && !itemType.Equals("HealthPotion") && !itemType.Equals("ArmorRepairKit"))
        {
            throw new ArgumentException($"Invalid item \"{itemType}\"!");
        }

        this.pool.Push(this.itemFactory.CreateItem(itemType));

        return $"{itemType} added to pool.";
    }

    public string PickUpItem(string[] args)
    {
        string charName = args[0];
        var character = this.characters.FirstOrDefault(x => x.Name.Equals(charName));

        if (character == null)
        {
            throw new ArgumentException($"Character {charName} not found!");
        }
        if(this.pool.Count < 1)
        {
            throw new InvalidOperationException("No items left in pool!");
        }
        var item = this.pool.Pop();
        character.ReceiveItem(item);
        return $"{charName} picked up {item.GetType().Name}!";
    }

    public string UseItem(string[] args)
    {
        string charName = args[0];
        string itemName = args[1];
        var character = this.characters.FirstOrDefault(x => x.Name.Equals(charName));

        if (character == null)
        {
            throw new ArgumentException($"Character {charName} not found!");
        }
        var item = character.Bag.GetItem(itemName);
        character.UseItem(item);
        return $"{character.Name} used {itemName}.";
    }

    public string UseItemOn(string[] args)
    {
        string giverName = args[0];
        string receiverName = args[1];
        string itemName = args[2];

        var giver = this.characters.FirstOrDefault(x => x.Name.Equals(giverName));
        var receiver = this.characters.FirstOrDefault(x => x.Name.Equals(receiverName));

        if (giver == null)
        {
            throw new ArgumentException($"Character {giverName} not found!");
        }
        if (receiver == null)
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }

        var item = giver.Bag.GetItem(itemName);
        giver.UseItemOn(item, receiver);
        
        return $"{giverName} used {itemName} on {receiverName}.";
    }

    public string GiveCharacterItem(string[] args)
    {
        string giverName = args[0];
        string receiverName = args[1];
        string itemName = args[2];

        var giver = this.characters.FirstOrDefault(x => x.Name.Equals(giverName));
        var receiver = this.characters.FirstOrDefault(x => x.Name.Equals(giverName));

        if (giver == null)
        {
            throw new ArgumentException($"Character {giverName} not found!");
        }
        if (receiver == null)
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }

        var item = giver.Bag.GetItem(itemName);
        giver.GiveCharacterItem(item, receiver);

        return $"{giverName} gave {receiverName} {itemName}.";
    }

    public string GetStats()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var character in this.characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
        {
            sb.AppendLine(character.ToString());
        }

        return sb.ToString().Trim();
    }

    public string Attack(string[] args)
    {
        string attackerName = args[0];
        string receiverName = args[1];

        var attacker = this.characters.FirstOrDefault(x => x.Name.Equals(attackerName));
        var receiver = this.characters.FirstOrDefault(x => x.Name.Equals(receiverName));

        if (attacker == null)
        {
            throw new ArgumentException($"Character {attackerName} not found!");
        }
        if (receiver == null)
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }
        if(attacker is Cleric)
        {
            throw new ArgumentException($"{attacker.Name} cannot attack!");
        }
        StringBuilder sb = new StringBuilder();

        ((Warrior)attacker).Attack(receiver);

        sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

        if (!receiver.IsAlive)
        {
            sb.AppendLine($"{receiver.Name} is dead!");
        }

        return sb.ToString().Trim();
    }

    public string Heal(string[] args)
    {
        string healerName = args[0];
        string healingreceiverName = args[1];

        var healer = this.characters.FirstOrDefault(x => x.Name.Equals(healerName));
        var receiver = this.characters.FirstOrDefault(x => x.Name.Equals(healingreceiverName));

        if (healer == null)
        {
            throw new ArgumentException($"Character {healerName} not found!");
        }
        if (receiver == null)
        {
            throw new ArgumentException($"Character {healingreceiverName} not found!");
        }
        if (healer is Warrior)
        {
            throw new ArgumentException($"{healerName} cannot heal!");
        }
        (healer as Cleric).Heal(receiver);

        return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
    }

    public string EndTurn(string[] args)
    {
        StringBuilder sb = new StringBuilder();

        var temp = this.characters.Where(x => x.IsAlive).ToList();

        if(temp.Count <= 1)
        {
            this.IncrementSurvivorRounds++;
        }

        foreach (var characterAlive in temp)
        {
            sb.Append($"{characterAlive.Name} rests ({characterAlive.Health}");
            characterAlive.Rest();
            sb.AppendLine($" => {characterAlive.Health})");
        }

        return sb.ToString().Trim();
    }

    public bool IsGameOver()
    {
        return this.IncrementSurvivorRounds > 1;
    }

}
