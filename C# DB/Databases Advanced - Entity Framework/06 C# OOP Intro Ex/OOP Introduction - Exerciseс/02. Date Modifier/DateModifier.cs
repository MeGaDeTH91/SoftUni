using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

class DateModifier
{
    private string startDate;
    private string endDate;

    public DateModifier(string startDate, string endDate)
    {
        this.StartDate = startDate;
        this.EndDate = endDate;
    }

    public string StartDate
    {
        get
        {
            return this.startDate;
        }
        set
        {
            this.startDate = value;
        }
    }
    
    public string EndDate
    {
        get
        {
            return this.endDate;
        }
        set
        {
            this.endDate = value;
        }
    }

    public long DayDiff(string stDate, string endDate)
    {
        long difference = 0;

        DateTime startDate = DateTime.ParseExact(stDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime enDate = DateTime.ParseExact(endDate, "yyyy MM dd", CultureInfo.InvariantCulture);

        difference = (enDate - startDate).Days;

        return Math.Abs(difference);
    }
}
