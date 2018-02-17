using System;
using System.Collections.Generic;
using System.Linq;
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

    public string GetMeTheDamnCat(string catName)
    {
        StringBuilder sb = new StringBuilder();

        Siamese siamCat = this.SiameseCats.FirstOrDefault(x => x.Name == catName);
        if(siamCat != null)
        {
            sb.AppendLine($"Siamese {siamCat.Name} {siamCat.EarSize}");
            return sb.ToString().TrimEnd();
        }

        Cymric cymrCat = this.CymricCats.FirstOrDefault(x => x.Name == catName);
        if (cymrCat != null)
        {
            sb.AppendLine($"Cymric {cymrCat.Name} {cymrCat.FurLength:F2}");
            return sb.ToString().TrimEnd();
        }

        StreetExtraordinaire streetCat = this.StreetExtraordinaireCats.FirstOrDefault(x => x.Name == catName);
        if (streetCat != null)
        {
            sb.AppendLine($"StreetExtraordinaire {streetCat.Name} {streetCat.MeowDecibels}");
            return sb.ToString().TrimEnd();
        }
        return string.Empty;

    }
}
