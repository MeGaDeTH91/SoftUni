using System;
using System.Globalization;

public class Song
{
    private string artistName;
    private string songName;    
    private long minutes;
    private long seconds;
    public TimeSpan Duration => this.GetMeTheDuration();

    public Song(string artistName, string songName, long minutes, long seconds)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }
    public Song()
    {

    }

    private string ArtistName
    {
        get
        {
            return this.artistName;
        }
        set
        {
            if(value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }
            this.artistName = value;
        }
    }
    private string SongName
    {
        get
        {
            return this.songName;
        }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }
            this.songName = value;
        }
    }
    private long Minutes
    {
        get
        {
            return this.minutes;
        }
        set
        {
            if(value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }
            this.minutes = value;
        }
    }
    private long Seconds
    {
        get
        {
            return this.seconds;
        }
        set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }
            this.seconds = value;
        }
    }

    private TimeSpan GetMeTheDuration()
    {
        DateTime startTime = DateTime.ParseExact("0:0", "m:s", CultureInfo.InvariantCulture);
        DateTime endTime = DateTime.ParseExact($"{this.Minutes.ToString()}:{this.Seconds.ToString()}", "m:s", CultureInfo.InvariantCulture);
        TimeSpan songDuration = endTime - startTime;

        return songDuration;
    }
}
