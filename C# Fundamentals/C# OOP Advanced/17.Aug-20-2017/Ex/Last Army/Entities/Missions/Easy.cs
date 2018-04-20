using System;

public class Easy : Mission
{
    const string EasyMissionName = "Suppression of civil rebellion";
    const int MissionEndurance = 20;
    const int MissionWearLevel = 30;

    public Easy(double scoreToComplete) : base(scoreToComplete)
    {
        this.Name = EasyMissionName;
        this.EnduranceRequired = MissionEndurance;
        this.WearLevelDecrement = MissionWearLevel;
    }
}
