using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_OnlineRadioDb
{
    class P04_OnlineRadioDb
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songList = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] currentInputLine = Console.ReadLine().Split(';').ToArray();

                    string currArtist = currentInputLine[0];
                    string currSong = currentInputLine[1];

                    string[] minSec = currentInputLine[2].Split(':').ToArray();

                    long currMins;
                    long currSec;

                    bool minParse = long.TryParse(minSec[0], out currMins);
                    bool secParse = long.TryParse(minSec[1], out currSec);

                    if(minSec.Length != 2 || !minParse || !secParse)
                    {
                        throw new InvalidSongLengthException();
                    }

                    Song songToAdd = new Song(currArtist, currSong, currMins, currSec);

                    songList.Add(songToAdd);
                    Console.WriteLine("Song added.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            int playListHours = songList.Sum(x => x.Duration.Hours);
            int playListMinutes = songList.Sum(x => x.Duration.Minutes);
            int playListSec = songList.Sum(x => x.Duration.Seconds);

            TimeSpan fullTime = new TimeSpan(playListHours, playListMinutes, playListSec);

            Console.WriteLine($"Songs added: {songList.Count}");
            Console.WriteLine($"Playlist length: {fullTime.Hours}h {fullTime.Minutes}m {fullTime.Seconds}s");
        }
    }
}
