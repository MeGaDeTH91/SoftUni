using System.Collections.Generic;

public class WaterNation : Nation
{
    List<Bender> WaterBenders;
    List<Monument> WaterMonuments;

    public WaterNation()
    {
        this.WaterBenders = new List<Bender>();
        this.WaterMonuments = new List<Monument>();
    }
}
