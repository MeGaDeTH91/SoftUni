using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

class Song
{
    private string artistName;
    private string name;
    private int minutes;
    private int seconds;
    private TimeSpan songLength;

    public Song()
    {

    }

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        this.ArtistName = artistName;
        this.Name = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public string ArtistName
    {
        get
        {
            return this.name;
        }
        set
        {
            if(value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            }
            this.artistName = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if(value.Length < 3 || value.Length > 30)
            {
                throw new ArgumentException("Song name should be between 3 and 30 symbols.");
            }
            this.name = value;
        }
    }

    public TimeSpan GetSongLength(string date)
    {
        string zeroTime = "0:0";
        DateTime start = DateTime.ParseExact(zeroTime, "m:s", CultureInfo.InvariantCulture);
        DateTime end = DateTime.ParseExact(date, "m:s", CultureInfo.InvariantCulture);
        TimeSpan time = end - start;
        return time;
    }

    public TimeSpan SongLength
    {
        get
        {
            return this.songLength;
        }
        set
        {
            this.songLength = value;
        }
    }

    public int Minutes
    {
        get
        {
            return this.minutes;
        }
        set
        {
            if(value < 0 || value > 14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }
            this.minutes = value;
        }
    }

    public int Seconds
    {
        get
        {
            return this.seconds;
        }
        set
        {
            if (value < 0 || value > 59)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }
            this.seconds = value;
        }
    }
}