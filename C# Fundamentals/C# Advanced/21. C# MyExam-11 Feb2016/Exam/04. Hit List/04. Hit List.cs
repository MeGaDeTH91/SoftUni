namespace _04._Hit_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, string>> persons = new Dictionary<string, Dictionary<string, string>>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "end transmissions")
            {
                List<string> currInputTokens = inputLine.Split(new[] { '=', ':', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string currentName = currInputTokens[0];
                currInputTokens.RemoveAt(0);
                for (int index = 0; index < currInputTokens.Count; index+= 2)
                {
                    string currSubKey = currInputTokens[index];
                    string currSubValue = currInputTokens[index + 1];

                    if (!persons.ContainsKey(currentName))
                    {
                        persons[currentName] = new Dictionary<string, string>();
                    }

                    if(!persons[currentName].ContainsKey(currSubKey))
                    {
                        persons[currentName][currSubKey] = currSubValue;
                    }
                    else
                    {
                        persons[currentName][currSubKey] = currSubValue;
                    }
                }


            }
            string[] lastCommand = Console.ReadLine()
                                   .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();
            string killName = lastCommand[1];

            if (persons.ContainsKey(killName))
            {
                int infoIndex = 0;
                Console.WriteLine($"Info on {killName}:");
                foreach (var personDetail in persons[killName].OrderBy(x => x.Key))
                {
                    infoIndex += personDetail.Key.Length;
                    infoIndex += personDetail.Value.Length;
                    
                    Console.WriteLine($"---{personDetail.Key}: {personDetail.Value}");
                }
                Console.WriteLine($"Info index: {infoIndex}");
                int diff = Math.Abs(infoIndex - targetInfoIndex);
                if(infoIndex >= targetInfoIndex)
                {
                    Console.WriteLine($"Proceed");
                }
                else
                {
                    Console.WriteLine($"Need {diff} more info.");
                }
            }
        }
    }
}
