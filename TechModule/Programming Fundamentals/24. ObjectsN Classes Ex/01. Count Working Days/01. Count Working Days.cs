using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _01.Count_Working_Days
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputSt = Console.ReadLine();
            string inputEnd = Console.ReadLine();
            DateTime start = DateTime.ParseExact(inputSt, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime end = DateTime.ParseExact(inputEnd, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            List<DateTime> excludeMe = new List<DateTime>();
            excludeMe.Add(new DateTime(4, 1, 1));
            excludeMe.Add(new DateTime(4, 3, 3));
            excludeMe.Add(new DateTime(4, 5, 1));
            excludeMe.Add(new DateTime(4, 5, 6));
            excludeMe.Add(new DateTime(4, 5, 24));
            excludeMe.Add(new DateTime(4, 9, 6));
            excludeMe.Add(new DateTime(4, 9, 22));
            excludeMe.Add(new DateTime(4, 11, 1));
            excludeMe.Add(new DateTime(4, 12, 24));
            excludeMe.Add(new DateTime(4, 12, 25));
            excludeMe.Add(new DateTime(4, 12, 26));

            List<DayOfWeek> weekends = new List<DayOfWeek>();
            weekends.Add(DayOfWeek.Saturday);
            weekends.Add(DayOfWeek.Sunday);
            long workingDays = 0;
            for (DateTime i = start; i <= end; i = i.AddDays(1))
            {
                DayOfWeek DayInWeek = i.DayOfWeek;
                DateTime temp = new DateTime(4, i.Month, i.Day);
                if (!excludeMe.Contains(temp) && (i.DayOfWeek != DayOfWeek.Saturday) && (i.DayOfWeek != DayOfWeek.Sunday))
                {
                    workingDays++;
                }
            }
            Console.WriteLine(workingDays);
        }
    }
}
