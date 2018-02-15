using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _03.Jarvis
{
    class Head
    {
        public int EnergyConsumption { get; set; }
        public int IQ { get; set; }
        public string SkinMaterial { get; set; }
    }
    class Arm
    {
        public long EnergyConsumption { get; set; }
        public long ArmReachDistance { get; set; }
        public long CountOfFingers { get; set; }
    }
    class Torso
    {
        public int EnergyConsumption { get; set; }
        public double ProcSizeInCm { get; set; }
        public string HousingMaterial { get; set; }
    }
    class Leg
    {
        public long EnergyConsumption { get; set; }
        public long Strength { get; set; }
        public long Speed { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger energyCap = BigInteger.Parse(Console.ReadLine());
            Head robotHead = new Head();
            robotHead.EnergyConsumption = int.MaxValue;
            List <Arm> robotArms = new List<Arm>();
            robotArms.Select(x => x.EnergyConsumption = int.MaxValue);
            Torso robotTorso = new Torso();
            robotTorso.EnergyConsumption = int.MaxValue;
            List<Leg> robotLegs = new List<Leg>();
            robotLegs.Select(x => x.EnergyConsumption = int.MaxValue);
           
            string command = Console.ReadLine();
            while (command != "Assemble!")
            {
                string[] currCommand = command.Split(' ')
                    .ToArray();
                Arm currArm = new Arm();
                Leg currLeg = new Leg();
                
                string currComponent = currCommand[0].ToLower();
                int currEnergyConsum = int.Parse(currCommand[1]);
                if(currComponent == "head")
                {
                    int currIQ = int.Parse(currCommand[2]);
                    string currSkinMat = currCommand[3];
                    if(currEnergyConsum < robotHead.EnergyConsumption)
                    {
                        robotHead.EnergyConsumption = currEnergyConsum;
                        robotHead.IQ = currIQ;
                        robotHead.SkinMaterial = currSkinMat;
                    } 
                }
                else if (currComponent == "arm")
                {
                    long currArmReach = long.Parse(currCommand[2]);
                    long currFingersNum = long.Parse(currCommand[3]);
                    currArm.EnergyConsumption = currEnergyConsum;
                    currArm.ArmReachDistance = currArmReach;
                    currArm.CountOfFingers = currFingersNum;
                    

                    if (robotArms.Count < 2)
                    {
                        robotArms.Add(currArm);
                    }
                    else
                    {
                        for (int i = 0; i < robotArms.Count; i++)
                        {
                            if(currArm.EnergyConsumption < robotArms[i].EnergyConsumption)
                            {
                                robotArms.RemoveAt(i);
                                robotArms.Add(currArm);
                            }
                        }
                    }        
                }
                else if (currComponent == "torso")
                {
                    double currProcSize = double.Parse(currCommand[2]);
                    string currHousingMaterial = currCommand[3];
                    if(currEnergyConsum < robotTorso.EnergyConsumption)
                    {
                        robotTorso.EnergyConsumption = currEnergyConsum;
                        robotTorso.ProcSizeInCm = currProcSize;
                        robotTorso.HousingMaterial = currHousingMaterial;
                    }
                }
                else if (currComponent == "leg")
                {
                    long currStrength = long.Parse(currCommand[2]);
                    long currSpeed = long.Parse(currCommand[3]);

                    currLeg.EnergyConsumption = currEnergyConsum;
                    currLeg.Strength = currStrength;
                    currLeg.Speed = currSpeed;

                    if (robotLegs.Count < 2)
                    {
                        robotLegs.Add(currLeg);
                    }
                    else
                    {
                        for (int i = 0; i < robotLegs.Count; i++)
                        {
                            if (currLeg.EnergyConsumption < robotLegs[i].EnergyConsumption)
                            {
                                robotLegs.RemoveAt(i);
                                robotLegs.Add(currLeg);
                            }
                        }
                    }

                }
                command = Console.ReadLine();
            }
            if(robotHead.SkinMaterial == null || robotArms.Count < 2 ||
                robotTorso.HousingMaterial == null || robotLegs.Count < 2)
                
            {
                Console.WriteLine("We need more parts!");
                return;
            }
            List<Arm> sortedArms = new List<Arm>();
            List<Leg> sortedLegs = new List<Leg>();
            if (robotArms.Count == 2)
            {
                 sortedArms = robotArms.OrderBy(x => x.EnergyConsumption).ToList();
            }
            if (robotLegs.Count == 2)
            {
                 sortedLegs = robotLegs.OrderBy(x => x.EnergyConsumption).ToList();
            }
               

                BigInteger sum = robotHead.EnergyConsumption + robotArms.Select(x => x.EnergyConsumption).Sum() + robotLegs.Select(x => x.EnergyConsumption).Sum() +
                    robotTorso.EnergyConsumption;
                var diff = energyCap - sum;
                if(diff >= 0)
                {
                    Console.WriteLine("Jarvis:");
                    Console.WriteLine("#Head:");
                    Console.WriteLine($"###Energy consumption: {robotHead.EnergyConsumption}");
                    Console.WriteLine($"###IQ: {robotHead.IQ}");
                    Console.WriteLine($"###Skin material: {robotHead.SkinMaterial}");
                    Console.WriteLine($"#Torso:");
                    Console.WriteLine($"###Energy consumption: {robotTorso.EnergyConsumption}");
                    Console.WriteLine($"###Processor size: {robotTorso.ProcSizeInCm:F1}");
                    Console.WriteLine($"###Corpus material: {robotTorso.HousingMaterial}");
                    Console.WriteLine($"#Arm:");
                    Console.WriteLine($"###Energy consumption: {sortedArms[0].EnergyConsumption}");
                    Console.WriteLine($"###Reach: {sortedArms[0].ArmReachDistance}");
                    Console.WriteLine($"###Fingers: {sortedArms[0].CountOfFingers}");
                    Console.WriteLine($"#Arm:");
                    Console.WriteLine($"###Energy consumption: {sortedArms[1].EnergyConsumption}");
                    Console.WriteLine($"###Reach: {sortedArms[1].ArmReachDistance}");
                    Console.WriteLine($"###Fingers: {sortedArms[1].CountOfFingers}");
                    Console.WriteLine("#Leg:");
                    Console.WriteLine($"###Energy consumption: {sortedLegs[0].EnergyConsumption}");
                    Console.WriteLine($"###Strength: {sortedLegs[0].Strength}");
                    Console.WriteLine($"###Speed: {sortedLegs[0].Speed}");
                    Console.WriteLine("#Leg:");
                    Console.WriteLine($"###Energy consumption: {sortedLegs[1].EnergyConsumption}");
                    Console.WriteLine($"###Strength: {sortedLegs[1].Strength}");
                    Console.WriteLine($"###Speed: {sortedLegs[1].Speed}");
                    return;
                }
                else
                {
                    Console.WriteLine("We need more power!");
                    return;
                }
            }
        }
    }
