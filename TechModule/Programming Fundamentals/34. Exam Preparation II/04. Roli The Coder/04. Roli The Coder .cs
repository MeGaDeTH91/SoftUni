using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _04.Roli_The_Coder
{
    class Event
    {
        public string Name { get; set; }
        public List<string> Participants { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<ID>[0-9]+)([ ]+)([#])(?<event>[A-Za-z0-9]+)([ ]+)*(?<participant>[@A-Za-z0-9 ]+)*$";
            string input = Console.ReadLine();
            Dictionary<BigInteger, Event> events = new Dictionary<BigInteger, Event>();
            while (input != "Time for Code")
            {
                string[] inputDetails = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Match currMatch = Regex.Match(input, pattern);
                if(currMatch.Success)
                {
                    BigInteger currID = BigInteger.Parse(inputDetails[0]);
                    char[] temp = inputDetails[1].ToCharArray();
                    string currEvent = string.Empty;
                    for (int i = 1; i < temp.Length; i++)
                    {
                        currEvent += temp[i].ToString();
                    }
                    
                    List<string> currParticipants = new List<string>();
                    for (int i = 2; i < inputDetails.Length; i++)
                    {
                        currParticipants.Add(inputDetails[i]);
                    }
                    if(!events.ContainsKey(currID))
                    {
                        List<string> tempParticip = new List<string>();
                        
                        for (int i = 0; i < currParticipants.Count; i++)
                        {
                            tempParticip.Add(currParticipants[i]);
                        }
                        tempParticip = tempParticip.Distinct().ToList();
                        events[currID] = new Event();
                        events[currID].Name = currEvent;
                        events[currID].Participants = new List<string>(tempParticip);
                    }
                    else
                    {
                        if(events[currID].Name == currEvent)
                        {
                            List<string> tempParticip = new List<string>();
                            for (int i = 0; i < events[currID].Participants.Count; i++)
                            {
                                tempParticip.Add(events[currID].Participants[i]);
                            }
                            for (int i = 0; i < currParticipants.Count; i++)
                            {
                                tempParticip.Add(currParticipants[i]);
                            }
                            tempParticip = tempParticip.Distinct().ToList();
                            events[currID].Participants = new List<string>(tempParticip);
                        }
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var currEvent in events.OrderByDescending(x => x.Value.Participants.Count).ThenBy(x => x.Value.Name))
            {
                Console.WriteLine($"{currEvent.Value.Name} - {currEvent.Value.Participants.Count}");
                foreach (var currParticipant in currEvent.Value.Participants.OrderBy(x => x))
                {
                    Console.WriteLine(currParticipant);
                }
            }
        }
    }
}
