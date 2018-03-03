using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    private List<Mission> missions;

    public List<Mission> Missions
    {
        get { return missions; }
        set { missions = value; }
    }

    public Commando(int id, string firstName, string lastName, decimal salary, CorpsType corps, List<Mission> missions) : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = missions;
    }

    public Commando(int id, string firstName, string lastName, decimal salary, CorpsType corps) : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = new List<Mission>();
    }

    public void CompleteMission(string codeName)
    {
        var missionToComplete = this.Missions.FirstOrDefault(x => x.CodeName == codeName);

        if(missionToComplete != null)
        {
            missionToComplete.State = StateType.Finished;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
        sb.AppendLine($"Corps: {this.Corps.ToString()}");
        sb.AppendLine($"Missions:");
        foreach (var mission in this.Missions)
        {
            sb.AppendLine(mission.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}
