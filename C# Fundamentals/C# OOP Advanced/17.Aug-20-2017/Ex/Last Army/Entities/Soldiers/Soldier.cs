using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private string name;

    private int age;

    private double experience;
    
    private double endurance;

    public Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = this.InitializeWeapons();
    }

    private IDictionary<string, IAmmunition> InitializeWeapons()
    {
        Dictionary<string, IAmmunition> weapons = new Dictionary<string, IAmmunition>();

        foreach (var wep in WeaponsAllowed)
        {
            weapons.Add(wep, null);
        }
        return weapons;
    }

    public IDictionary<string, IAmmunition> Weapons { get; }
    
    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public virtual double OverallSkill => this.Age + this.Experience;

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

    public virtual void Regenerate()
    {
        this.Endurance += (10.0d + this.Age); 
    }

    public void CompleteMission(IMission mission)
    {
        this.Endurance -= mission.EnduranceRequired;
        this.Experience += mission.EnduranceRequired;

        this.CheckAmmunitions(mission.WearLevelDecrement);
    }

    private void CheckAmmunitions(double wearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(wearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        protected set { this.age = value; }
    }

    public double Experience
    {
        get
        {
            return this.experience;
        }
        protected set
        {
            this.experience = value;
        }
    }

    public double Endurance
    {
        get
        {
            return this.endurance;
        }
        protected set
        {
            if(value > 100)
            {
                value = 100;
            }
            this.endurance = value;
        }
    }
}