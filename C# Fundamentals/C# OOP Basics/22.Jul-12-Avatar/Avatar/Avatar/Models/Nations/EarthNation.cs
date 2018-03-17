using System.Collections.Generic;

public class EarthNation : Nation
{
    List<Bender> EarthBenders;
    List<Monument> EarthMonuments;

    public EarthNation()
    {
        this.EarthBenders = new List<Bender>();
        this.EarthMonuments = new List<Monument>();
    }
}
