using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double OverallSkillMultiplier = 3.5d;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
        };

    public SpecialForce(string name, int age, double experience, double endurance) : base(name, age, experience, endurance)
    {
    }

    public override double OverallSkill => base.OverallSkill * OverallSkillMultiplier;

    protected override IReadOnlyList<string> WeaponsAllowed { get { return this.weaponsAllowed.AsReadOnly(); } }

    public override void Regenerate()
    {
        this.Endurance += (30.0d + this.Age);
    }
}