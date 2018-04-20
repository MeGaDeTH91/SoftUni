using System;

public class Hard : Mission
{
    const string HardMissionName = "Disposal of terrorists";
    const int MissionEndurance = 80;
    const int MissionWearLevel = 70;

    public Hard(double scoreToComplete) : base(scoreToComplete)
    {
        this.Name = HardMissionName;
        this.EnduranceRequired = MissionEndurance;
        this.WearLevelDecrement = MissionWearLevel;
    }
}
