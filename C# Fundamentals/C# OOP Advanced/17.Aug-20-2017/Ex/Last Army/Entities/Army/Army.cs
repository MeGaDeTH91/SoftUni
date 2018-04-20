using System.Collections.Generic;

public class Army : IArmy
{
    private List<ISoldier> soldiers;

    public IReadOnlyList<ISoldier> Soldiers { get { return this.soldiers.AsReadOnly(); } }

    public Army()
    {
        this.soldiers = new List<ISoldier>();
    }

    public void AddSoldier(ISoldier soldier)
    {
        this.soldiers.Add(soldier);
    }

    public void RegenerateTeam(string soldierType)
    {
        foreach (var soldier in this.soldiers)
        {
            if (soldier.GetType().Name == soldierType)
            {
                soldier.Regenerate();
            }
        }
    }
}
