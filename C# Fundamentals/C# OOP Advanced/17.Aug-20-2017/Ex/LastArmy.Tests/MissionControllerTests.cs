using NUnit.Framework;

public class MissionControllerTests
{
    [Test]
    public void SuccessMessageShouldWorkCorrectly()
    {
        IArmy army = new Army();
        IWareHouse wareHouse = new WareHouse();

        ISoldierFactory soldierFactory = new SoldierFactory();
        IMissionFactory missionFactory = new MissionFactory();

        IMission mission = missionFactory.CreateMission("Easy", 0);

        MissionController missionController = new MissionController(army, wareHouse);

        Assert.That(() => missionController.PerformMission(mission).Trim(), Is.EqualTo($"Mission completed - {mission.Name}"));
    }

    [Test]
    public void MissionControllerDisplaysFailMessage()
    {
        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        var mission = new Easy(1);
        string result = "";
        for (int counter = 0; counter < 4; counter++)
        {
            result = missionController.PerformMission(mission);
        }

        Assert.IsTrue(result.StartsWith("Mission declined - Suppression of civil rebellion"));
    }
}
