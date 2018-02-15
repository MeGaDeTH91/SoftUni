using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<Song> songs = new List<Song>();

        int n = int.Parse(Console.ReadLine());

        
            for (int i = 0; i < n; i++)
            {
                Song currSong = new Song();

                
            try
            {
                string[] input = Console.ReadLine()
                    .Split(';').ToArray();

                string artistName = input[0];
                string songName = input[1];

                currSong.ArtistName = artistName;
                currSong.Name = songName;

                int minutes1 = 0;
                int seconds1 = 0;

                    string[] secInput = input[2].Split(':').ToArray();

                    if (secInput.Length != 2 || !int.TryParse((secInput[0]), out minutes1) || !int.TryParse((secInput[1]), out seconds1))
                    {
                        throw new ArgumentException("Invalid song length.");
                    }

                currSong.Minutes = minutes1;
                currSong.Seconds = seconds1;
                TimeSpan currLenght = currSong.GetSongLength(input[2]);
                currSong.SongLength = currLenght;

                songs.Add(currSong);
                Console.WriteLine("Song added.");
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
            }
        }
        
        int hours = songs.Sum(x => x.SongLength.Hours);
        int minutes = songs.Sum(x => x.SongLength.Minutes);
        int seconds = songs.Sum(x => x.SongLength.Seconds);
        TimeSpan fullLength = new TimeSpan(hours,minutes,seconds);

        Console.WriteLine($"Songs added: {songs.Count}");
        Console.WriteLine($"Playlist length: {fullLength.Hours}h {fullLength.Minutes}m {fullLength.Seconds}s");
    }
}