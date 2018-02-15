using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string start = Console.ReadLine();
        string end = Console.ReadLine();

        DateModifier dates = new DateModifier(start, end);

        long diff = dates.DayDiff(dates.StartDate, dates.EndDate);

        Console.WriteLine(diff);
    }
}