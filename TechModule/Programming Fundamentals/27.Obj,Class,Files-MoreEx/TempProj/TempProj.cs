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
        public int EnergyConsumption { get; set; }
        public int ArmReachDistance { get; set; }
        public int CountOfFingers { get; set; }
    }
    class Torso
    {
        public int EnergyConsumption { get; set; }
        public double ProcSizeInCm { get; set; }
        public string HousingMaterial { get; set; }
    }
    class Leg
    {
        public int EnergyConsumption { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ulong energyCap = ulong.Parse(Console.ReadLine());
            Head robotHead = new Head();
            robotHead.EnergyConsumption = int.MaxValue;
            Arm robotLeftArm = new Arm();
            robotLeftArm.EnergyConsumption = int.MaxValue;
            Arm robotRightArm = new Arm();
            robotRightArm.EnergyConsumption = int.MaxValue;
            Torso robotTorso = new Torso();
            robotTorso.EnergyConsumption = int.MaxValue;
            Leg robotLeftLeg = new Leg();
            robotLeftLeg.EnergyConsumption = int.MaxValue;
            Leg robotRightLeg = new Leg();
            robotRightLeg.EnergyConsumption = int.MaxValue;

            int legCounter = -1;
            int armCounter = -1;
            string command = Console.ReadLine();
            while (command != "Assemble!")
            {
                string[] currCommand = command.Split(' ')
                    .ToArray();
                //Head head = new Head();
                //Arm leftArm = new Arm();
                //Arm rightArm = new Arm();
                //Torso torso = new Torso();
                //Leg leftLeg = new Leg();
                //Leg rightLeg = new Leg();

                string currComponent = currCommand[0].ToLower();
                int currEnergyConsum = int.Parse(currCommand[1]);
                if (currComponent == "head")
                {
                    int currIQ = int.Parse(currCommand[2]);
                    string currSkinMat = currCommand[3];
                    if (currEnergyConsum < robotHead.EnergyConsumption)
                    {
                        robotHead.EnergyConsumption = currEnergyConsum;
                        robotHead.IQ = currIQ;
                        robotHead.SkinMaterial = currSkinMat;
                    }

                }
                else if (currComponent == "arm")
                {
                    int currArmReach = int.Parse(currCommand[2]);
                    int currFingersNum = int.Parse(currCommand[3]);

                    var oldEncons = 0;
                    var oldArmReach = 0;
                    var oldFingers = 0;
                    if (currEnergyConsum < robotLeftArm.EnergyConsumption)
                    {
                        oldEncons = robotLeftArm.EnergyConsumption;
                        oldArmReach = robotLeftArm.ArmReachDistance;
                        oldFingers = robotLeftArm.CountOfFingers;

                        robotLeftArm.EnergyConsumption = currEnergyConsum;
                        robotLeftArm.ArmReachDistance = currArmReach;
                        robotLeftArm.CountOfFingers = currFingersNum;
                        armCounter++;
                        if (armCounter == 0)
                        {
                            continue;
                        }
                    }
                    else if (currEnergyConsum < robotLeftLeg.EnergyConsumption && currEnergyConsum < robotRightLeg.EnergyConsumption)
                    {
                        robotLeftArm.EnergyConsumption = currEnergyConsum;
                        robotLeftArm.ArmReachDistance = currArmReach;
                        robotLeftArm.CountOfFingers = currFingersNum;
                    }

                    robotRightArm.EnergyConsumption = oldEncons;
                    robotRightArm.ArmReachDistance = oldArmReach;
                    robotRightArm.CountOfFingers = oldFingers;
                }
                else if (currComponent == "torso")
                {
                    double currProcSize = double.Parse(currCommand[2]);
                    string currHousingMaterial = currCommand[3];
                    if (currEnergyConsum < robotTorso.EnergyConsumption)
                    {
                        robotTorso.EnergyConsumption = currEnergyConsum;
                        robotTorso.ProcSizeInCm = currProcSize;
                        robotTorso.HousingMaterial = currHousingMaterial;
                    }
                }
                else if (currComponent == "leg")
                {
                    int currStrength = int.Parse(currCommand[2]);
                    int currSpeed = int.Parse(currCommand[3]);
                    if (currEnergyConsum < robotLeftLeg.EnergyConsumption || currEnergyConsum < robotRightLeg.EnergyConsumption)
                    {
                        var oldEncons = 0;
                        var oldStr = 0;
                        var oldSpeed = 0;
                        if (currEnergyConsum < robotLeftLeg.EnergyConsumption)
                        {
                            oldEncons = robotLeftLeg.EnergyConsumption;
                            oldStr = robotLeftLeg.Strength;
                            oldSpeed = robotLeftLeg.Speed;

                            robotLeftLeg.EnergyConsumption = currEnergyConsum;
                            robotLeftLeg.Strength = currStrength;
                            robotLeftLeg.Speed = currSpeed;
                            legCounter++;
                            if (legCounter == 0)
                            {
                                continue;
                            }
                        }
                        else if (currEnergyConsum < robotLeftLeg.EnergyConsumption && currEnergyConsum < robotRightLeg.EnergyConsumption)
                        {
                            robotLeftLeg.EnergyConsumption = currEnergyConsum;
                            robotLeftLeg.Strength = currStrength;
                            robotLeftLeg.Speed = currSpeed;
                        }

                        robotRightLeg.EnergyConsumption = oldEncons;
                        robotRightLeg.Strength = oldStr;
                        robotRightLeg.Speed = oldSpeed;
                    }

                }
                command = Console.ReadLine();
            }
            if ((robotHead.SkinMaterial == null && robotHead.IQ == 0) ||
                (robotLeftArm.EnergyConsumption == int.MaxValue && robotLeftArm.CountOfFingers == 0 && robotLeftArm.ArmReachDistance == 0) ||
                (robotRightArm.EnergyConsumption == int.MaxValue && robotRightArm.CountOfFingers == 0 && robotRightArm.ArmReachDistance == 0) ||
                robotTorso.HousingMaterial == null || (robotLeftLeg.EnergyConsumption == int.MaxValue && robotLeftLeg.Speed == 0 && robotLeftLeg.Strength == 0) ||
                (robotRightLeg.EnergyConsumption == int.MaxValue && robotRightLeg.Speed == 0 && robotRightLeg.Strength == 0))
            {
                Console.WriteLine("We need more parts!");
                return;
            }
            try
            {
                BigInteger sum = (BigInteger)(robotHead.EnergyConsumption + robotLeftArm.EnergyConsumption + robotRightArm.EnergyConsumption + robotTorso.EnergyConsumption
                    + robotLeftLeg.EnergyConsumption + robotRightLeg.EnergyConsumption);
                var diff = energyCap - sum;
                if (diff >= 0)
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
                    Console.WriteLine($"###Energy consumption: {robotLeftArm.EnergyConsumption}");
                    Console.WriteLine($"###Reach: {robotLeftArm.ArmReachDistance}");
                    Console.WriteLine($"###Fingers: {robotLeftArm.CountOfFingers}");
                    Console.WriteLine($"#Arm:");
                    Console.WriteLine($"###Energy consumption: {robotRightArm.EnergyConsumption}");
                    Console.WriteLine($"###Reach: {robotRightArm.ArmReachDistance}");
                    Console.WriteLine($"###Fingers: {robotRightArm.CountOfFingers}");
                    Console.WriteLine("#Leg:");
                    Console.WriteLine($"###Energy consumption: {robotLeftLeg.EnergyConsumption}");
                    Console.WriteLine($"###Strength: {robotLeftLeg.Strength}");
                    Console.WriteLine($"###Speed: {robotLeftLeg.Speed}");
                    Console.WriteLine("#Leg:");
                    Console.WriteLine($"###Energy consumption: {robotRightLeg.EnergyConsumption}");
                    Console.WriteLine($"###Strength: {robotRightLeg.Strength}");
                    Console.WriteLine($"###Speed: {robotRightLeg.Speed}");
                    return;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("We need more power!");
                return;
            }
        }
    }
}