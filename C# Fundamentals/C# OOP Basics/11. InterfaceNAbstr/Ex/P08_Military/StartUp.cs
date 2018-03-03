using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P08_Military
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Private> privates = new List<Private>();
            StringBuilder sb = new StringBuilder();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commTokens = command.Split();

                string soldierType = commTokens[0];
                int id = int.Parse(commTokens[1]);
                string firstName = commTokens[2];
                string lastName = commTokens[3];

                switch (soldierType)
                {
                    case "Private":
                        decimal privateSalary = decimal.Parse(commTokens[4]);
                        Private newPrivate = new Private(id, firstName, lastName, privateSalary);
                        sb.AppendLine(newPrivate.ToString());
                        privates.Add(newPrivate);
                        break;
                    case "LeutenantGeneral":
                        decimal leutenantSalary = decimal.Parse(commTokens[4]);
                        List<Private> tempPrivates = new List<Private>();
                        for (int i = 5; i < commTokens.Length; i++)
                        {
                            int currId = int.Parse(commTokens[i]);
                            var currPrivate = privates.FirstOrDefault(x => x.Id == currId);
                            if (currPrivate != null)
                            {
                                tempPrivates.Add(currPrivate);
                            }
                        }
                        LeutenantGeneral newLeut = new LeutenantGeneral(id, firstName, lastName, leutenantSalary, tempPrivates);
                        sb.AppendLine(newLeut.ToString());
                        break;
                    case "Engineer":
                        decimal engineerSalary = decimal.Parse(commTokens[4]);
                        CorpsType currEngCorps;
                        bool isEngCorpsValid = Enum.TryParse(commTokens[5], out currEngCorps);
                        if (isEngCorpsValid)
                        {
                            List<Repair> repairs = new List<Repair>();

                            for (int i = 6; i < commTokens.Length; i += 2)
                            {
                                string partName = commTokens[i];
                                int workHours = int.Parse(commTokens[i + 1]);
                                Repair newRepair = new Repair(partName, workHours);

                                repairs.Add(newRepair);
                            }
                            Engineer newEngineer = new Engineer(id, firstName, lastName, engineerSalary, currEngCorps, repairs);
                            sb.AppendLine(newEngineer.ToString());
                        }
                        break;
                    case "Commando":
                        decimal commandoSalary = decimal.Parse(commTokens[4]);
                        CorpsType currCorps;
                        bool isCorpsValid = Enum.TryParse(commTokens[5], out currCorps);
                        if (isCorpsValid)
                        {
                            List<Mission> missions = new List<Mission>();

                            for (int i = 6; i < commTokens.Length; i+=2)
                            {
                                string currCodeName = commTokens[i];
                                StateType missionState;
                                bool isMissionValid = Enum.TryParse(commTokens[i + 1], out missionState);
                                if (isMissionValid)
                                {
                                    Mission addMission = new Mission(currCodeName, missionState);
                                    missions.Add(addMission);
                                }
                            }
                            Commando newCommando = new Commando(id, firstName, lastName, commandoSalary, currCorps, missions);
                            sb.AppendLine(newCommando.ToString());
                        }
                        break;
                    case "Spy":
                        int codeNum = int.Parse(commTokens[4]);
                        Spy newSpy = new Spy(id, firstName, lastName, codeNum);
                        sb.AppendLine(newSpy.ToString());
                        break;
                    default:
                        break;
                }
            }
            string result = sb.ToString().TrimEnd();
            Console.WriteLine(result);
        }
    }
}
