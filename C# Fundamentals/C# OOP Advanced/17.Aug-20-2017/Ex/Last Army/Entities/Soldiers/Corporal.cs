﻿using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double OverallSkillMultiplier = 2.5d;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "Helmet",
            "Knife",
        };

    public Corporal(string name, int age, double experience, double endurance) : base(name, age, experience, endurance)
    {
        
    }

    public override double OverallSkill => base.OverallSkill * OverallSkillMultiplier;
    protected override IReadOnlyList<string> WeaponsAllowed { get { return this.weaponsAllowed.AsReadOnly(); } }
}
