using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

public class DateModifier
{
    private string startDate;
    private string endDate;
    public long days => this.GetDayNumber(StartDate, EndDate);

    public DateModifier()
    {

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
    
    public long GetDayNumber(string startDate, string endDate)
    {
        DateTime start = DateTime.ParseExact(startDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime end = DateTime.ParseExact(endDate, "yyyy MM dd", CultureInfo.InvariantCulture);

         long dayNum = Math.Abs((long)(end - start).TotalDays);

        return dayNum;
    }
}
