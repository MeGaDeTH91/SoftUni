using System;
using System.Collections.Generic;
using System.Text;

public class Hierarchy
{
    public List<Siamese> SiameseCats { get; set; }
    public List<Cymric> CymricCats { get; set; }
    public List<StreetExtraordinaire> StreetExtraordinaireCats { get; set; }

    public Hierarchy()
    {
        this.SiameseCats = new List<Siamese>();
        this.CymricCats = new List<Cymric>();
        this.StreetExtraordinaireCats = new List<StreetExtraordinaire>();
    }
}
