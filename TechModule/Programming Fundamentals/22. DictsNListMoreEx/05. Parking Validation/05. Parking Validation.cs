using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Parking_Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            int entryNum = int.Parse(Console.ReadLine());
            var registered = new Dictionary<string, string>();
            bool firstTwoLett = false;
            bool fourDigits = false;
            bool lastTwoLett = false;
            bool validNumber = true;
            for (int i = 0; i < entryNum; i++)
            {
                List<string> currentCommand = Console.ReadLine()
                    .Split(' ')
                    .ToList();
                string regOrUnreg = currentCommand[0];
                string personName = currentCommand[1];
                if(regOrUnreg == "register")
                {
                    string plateNum = currentCommand[2];
                    if (plateNum.Length != 8)
                    {
                        validNumber = false;
                    }
                    for (int j = 0; j < plateNum.Length; j++)
                    {
                        if((j >= 0 && j < 2) && char.IsUpper(plateNum[j]))
                        {
                            firstTwoLett = true;
                        }
                        else if((j >= 2 && j < 6) && char.IsNumber(plateNum[j]))
                        {
                            fourDigits = true;
                        }
                        else if((j >= 6) && char.IsUpper(plateNum[j]))
                        {
                            lastTwoLett = true;
                        }
                        else
                        {
                            validNumber = false;
                        }
                    }
                    if(registered.ContainsKey(personName))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {registered[personName]}");
                    }
                    else if(!validNumber)
                    {
                        Console.WriteLine($"ERROR: invalid license plate {plateNum}");
                        validNumber = true;
                    }
                    else if(registered.Any(x => x.Value.Contains(plateNum)) && (validNumber))
                    {
                        Console.WriteLine($"ERROR: license plate {plateNum} is busy");
                    }
                    else if(validNumber && firstTwoLett && fourDigits && lastTwoLett)
                    {
                        registered.Add(personName, plateNum);
                        Console.WriteLine($"{personName} registered {plateNum} successfully");
                    }
                }
                else if(regOrUnreg == "unregister")
                {
                    if(registered.ContainsKey(personName))
                    {
                        Console.WriteLine($"user {personName} unregistered successfully");
                        registered.Remove(personName);
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {personName} not found");
                    }
                }
            }
            foreach (var item in registered)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
