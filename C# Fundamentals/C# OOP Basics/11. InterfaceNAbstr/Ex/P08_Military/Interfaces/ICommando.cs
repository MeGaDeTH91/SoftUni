using System.Collections.Generic;

public interface ICommando
{
    List<Mission> Missions { get; set; }

    void CompleteMission(string codeName);
}