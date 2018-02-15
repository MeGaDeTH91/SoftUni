using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SoftUni_Karaoke
{
    class Record
    {
        
        public string Songs { get; set; }
        public List<string> Awards { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Record> myRecord = new Dictionary<string, Record>();
            string[] stringSeparators = new string[] { ", " };
            string[] participants = Console.ReadLine()
                .Split(", \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] songs = Console.ReadLine()
                .Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            string multiInput = Console.ReadLine();

            while (multiInput != "dawn")
            {
                Record currRec = new Record()
                {
                    Awards = new List<string>()
                };
                string[] currInput = multiInput.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string currParticipant = currInput[0];
                string currSong = currInput[1];
                string currAward = currInput[2];
                currRec.Songs = currSong;
                currRec.Awards.Add(currAward);
                if(participants.Contains(currParticipant) && songs.Contains(currSong))
                {
                    if (myRecord.Select(x => x.Key).Any(x => x.Contains(currParticipant)))
                    {
                        if (!myRecord.Select(x => x.Value.Awards).Any(x => x.Contains(currAward)))
                        {
                            myRecord[currParticipant].Songs = currSong;
                            myRecord[currParticipant].Awards.Add(currAward);
                        }
                    }
                    else
                    {
                        myRecord.Add(currParticipant, currRec);
                    }
                }
                multiInput = Console.ReadLine();
            }
            foreach (var item in myRecord.OrderByDescending(x => x.Value.Awards.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Awards.Count} awards");
                foreach (var award in item.Value.Awards.OrderBy(x => x))
                {
                    Console.WriteLine($"--{award}");
                }
            }
            if(myRecord.Count == 0)
            {
                Console.WriteLine("No awards");
            }
        }
    }
}
