using System;

public class OutputMessages
{
    public const string MissionSuccessful = "Mission completed - {0}";

    public const string MissionOnHold = "Mission on hold - {0}";

    public const string MissionDeclined = "Mission declined - {0}";

    // {type}, {name}
    public const string SoldierNoWeaponFailedToCreate = "There is no weapon for {0} {1}!";

    // {Name} {OverallSkill}
    public const string SoldierToString = "{0} - {1}";

    public const string SuccessfullMisionsCount = "Successful missions - {0}";

    public const string FailedMissionsCount = "Failed missions - {0}";
}
