using System.Collections.Generic;
using System.Linq;

public class AirNation : Nation
{
    List<Bender> AirBenders;
    List<Monument> AirMonuments;

    public AirNation()
    {
        this.AirBenders = new List<Bender>();
        this.AirMonuments = new List<Monument>();
    }
}
