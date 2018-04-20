public class Medium : Mission
{
    const string MediumMissionName = "Capturing dangerous criminals";
    const int MissionEndurance = 50;
    const int MissionWearLevel = 50;

    public Medium(double scoreToComplete) : base(scoreToComplete)
    {
        this.Name = MediumMissionName;
        this.EnduranceRequired = MissionEndurance;
        this.WearLevelDecrement = MissionWearLevel;
    }
}
