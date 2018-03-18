using System;
using System.Collections.Generic;
using System.Text;

public abstract class Character
{
    private const double Initial_RestHealMultiplier = 0.2d;

    private string name;
    private double baseHealth;
    private double health;
    private double baseArmor;
    private double armor;
    private double abilityPoints;
    private Bag bag;
    private Faction faction;
    private bool isAlive;
    private double restHealMultiplier;

    protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
    {
        this.Name = name;
        this.BaseHealth = health;
        this.Health = health;
        this.BaseArmor = armor;
        this.Armor = armor;
        this.AbilityPoints = abilityPoints;
        this.Bag = bag;
        this.Faction = faction;
        this.IsAlive = true;
        this.RestHealMultiplier = Initial_RestHealMultiplier;
    }

    public void TakeDamage(double hitPoints)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
        double armorLeft = this.Armor - hitPoints;
        if(armorLeft >= 0)
        {
            this.Armor -= hitPoints;
        }
        else
        {
            double leftDamage = hitPoints - this.Armor;

            this.Armor -= hitPoints;
            this.Health -= leftDamage;
        }

    }
    public void Rest()
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
        this.Health += (this.BaseHealth * this.RestHealMultiplier);
    }

    public void UseItem(Item item)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        item.AffectCharacter(this);
    }
    public void UseItemOn(Item item, Character character)
    {
        if (!this.IsAlive || !character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
        item.AffectCharacter(character);
    }
    public void GiveCharacterItem(Item item, Character character)
    {
        if (!this.IsAlive || !character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
        
        character.ReceiveItem(item);

    }
    public void ReceiveItem(Item item)
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
        this.Bag.AddItem(item);
    }

    public void GetHealedByCleric(double points)
    {
        this.Health += points;
    }
    public void HealthPotionHpIncrease(int points)
    {
        this.Health += points;
    }
    public void PosionPotionHpDecrease(int points)
    {
        this.Health -= points;
    }
    public void RepairArmor()
    {
        this.Armor = this.BaseArmor;
    }

    public string Name
    {
        get { return this.name; }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }
            this.name = value;
        }
    }

    public double BaseHealth
    {
        get { return this.baseHealth; }
        protected set
        {
            this.baseHealth = value;
        }
    }

    public double Health
    {
        get { return this.health; }
        protected set
        {
            if (value > this.BaseHealth)
            {
                this.health = this.BaseHealth;
            }
            else if (value <= 0)
            {
                this.health = 0;
                this.IsAlive = false;
            }
            else
            {
                this.health = value;
            }
        }
    }

    public double BaseArmor
    {
        get { return this.baseArmor; }
        protected set { this.baseArmor = value; }
    }

    public double Armor
    {
        get { return this.armor; }
        protected set
        {
            if (value >= this.BaseArmor)
            {
                this.armor = this.BaseArmor;
            }
            else if (value <= 0)
            {
                this.armor = 0;
            }
            else
            {
                this.armor = value;
            }
        }
    }

    public double AbilityPoints
    {
        get { return this.abilityPoints; }
        protected set { this.abilityPoints = value; }
    }

    public Bag Bag
    {
        get { return this.bag; }
        protected set { this.bag = value; }
    }

    public Faction Faction
    {
        get { return this.faction; }
        protected set { this.faction = value; }
    }

    public bool IsAlive
    {
        get { return this.isAlive; }
        protected set { this.isAlive = value; }
    }
    
    public virtual double RestHealMultiplier
    {
        get { return this.restHealMultiplier; }
        protected set { this.restHealMultiplier = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        string status = IsAlive? "Alive" : "Dead";
        
        sb.AppendLine($"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}");

        return sb.ToString().Trim();
    }
}
