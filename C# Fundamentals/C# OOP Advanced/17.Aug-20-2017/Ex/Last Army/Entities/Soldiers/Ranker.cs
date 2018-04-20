using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OverallSkillMultiplier = 1.5d;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "Helmet"
        };

    public Ranker(string name, int age, double experience, double endurance) : base(name, age, experience, endurance)
    {
        
    }

    public override double OverallSkill => base.OverallSkill * OverallSkillMultiplier;

    protected override IReadOnlyList<string> WeaponsAllowed { get { return this.weaponsAllowed.AsReadOnly(); } }
}
