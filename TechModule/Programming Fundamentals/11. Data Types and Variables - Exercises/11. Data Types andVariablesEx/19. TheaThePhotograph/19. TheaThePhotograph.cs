using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.TheaThePhotograph
{
    class Program
    {
        static void Main(string[] args)
        {
            long pictureNum = long.Parse(Console.ReadLine());
            long filterTime = long.Parse(Console.ReadLine());
            long filterFactorPercent = long.Parse(Console.ReadLine());
            long uploadTime = long.Parse(Console.ReadLine());

            double filteringTime = pictureNum * filterTime; 
            double filteredpicsN = Math.Ceiling(pictureNum * (filterFactorPercent / 100d));
            double goodpics = filteredpicsN * uploadTime;
            double totalTime = filteringTime + goodpics;


            TimeSpan projectTime = TimeSpan.FromSeconds(totalTime);

            Console.WriteLine("{0:D1}:{1:D2}:{2:D2}:{3:D2}",
                projectTime.Days,
                projectTime.Hours,
                projectTime.Minutes,
                projectTime.Seconds);
        }
    }
}
