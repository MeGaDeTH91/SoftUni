using System;
using System.Collections.Generic;
using System.Linq;

public class GameController
{
    private IArmy army;
    private IWareHouse wareHouse;
    private IReader reader;
    private IWriter writer;
    private MissionController missionController;

    private AmmunitionFactory ammunitionFactory;
    private SoldierFactory soldiersFactory;
    private MissionFactory missionFactory;

    public GameController(IReader reader, IWriter writer)
    {
        this.Army = new Army();
        this.WareHouse = new WareHouse();
        this.MissionControllerField = new MissionController(Army, WareHouse);
        this.soldiersFactory = new SoldierFactory();
        this.ammunitionFactory = new AmmunitionFactory();
        this.missionFactory = new MissionFactory();
        this.reader = reader;
        this.writer = writer;
    }

    public IArmy Army
    {
        get { return army; }
        private set { army = value; }
    }

    public IWareHouse WareHouse
    {
        get { return wareHouse; }
        private set { wareHouse = value; }
    }

    public MissionController MissionControllerField
    {
        get { return missionController; }
        private set { missionController = value; }
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0].Equals("Soldier"))
        {
            string type = string.Empty;
            string name = string.Empty;
            int age = 0;
            int experience = 0;
            double endurance = 0d;

            if (data.Length == 3)
            {
                type = data[1];
                name = data[2];
            }
            else
            {
                type = data[1];
                name = data[2];
                age = int.Parse(data[3]);
                experience = int.Parse(data[4]);
                endurance = double.Parse(data[5]);
            }

            switch (type)
            {
                case "Regenerate":
                    this.Army.RegenerateTeam(name);
                    break;
                default:
                    var soldier = this.soldiersFactory.CreateSoldier(type, name, age, experience, endurance);
                    AddSoldierToArmy(soldier, type);
                    break;
            }

        }
        else if (data[0].Equals("WareHouse"))
        {
            string name = data[1];
            int number = int.Parse(data[2]);

            AddAmmunitions(name, number);
            
            
        }
        else if (data[0].Equals("Mission"))
        {
            string missionType = data[1];
            double scoreToComplete = double.Parse(data[2]);

            IMission mission = this.missionFactory.CreateMission(missionType, scoreToComplete);
            this.writer.StoreMessage(this.MissionControllerField.PerformMission(mission));
        }
    }

    //public string RequestResult()
    //{
    //    return Output.GiveOutput(result, army, wareHouse, this.MissionControllerField.MissionQueue.Count);
    //}

    public void ProduceSummury()
    {
        List<ISoldier> orderedArmy = this.army.Soldiers.OrderByDescending(s => s.OverallSkill).ToList();
        this.missionController.FailMissionsOnHold();



        this.writer.StoreMessage("Results:");
        this.writer.StoreMessage(string.Format(OutputMessages.SuccessfullMisionsCount, this.missionController.SuccessMissionCounter));
        this.writer.StoreMessage(string.Format(OutputMessages.FailedMissionsCount, this.missionController.FailedMissionCounter));
        this.writer.StoreMessage("Soldiers:");
        foreach (var soldier in orderedArmy)
        {
            this.writer.StoreMessage(soldier.ToString());
        }
    }

    private void AddAmmunitions(string ammunition, int count)
    {
        this.WareHouse.AddAmmunitions(ammunition, count);
    }

    private void AddSoldierToArmy(ISoldier soldier, string type)
    {
        if (!this.wareHouse.TryEquipSoldier(soldier))
        {
            throw new ArgumentException(string.Format(OutputMessages.SoldierNoWeaponFailedToCreate, type, soldier.Name));
        }

        this.Army.AddSoldier(soldier);
    }
}