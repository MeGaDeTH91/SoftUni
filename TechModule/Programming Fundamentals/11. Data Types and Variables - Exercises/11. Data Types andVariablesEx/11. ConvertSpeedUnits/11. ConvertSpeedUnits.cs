using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ConvertSpeedUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            float exactSeconds = (float)((hours * 60.0 * 60.0) + (minutes * 60.0) + seconds);
            float meterPerSec = meters / exactSeconds;

            float kiloMeters = meters / 1000f;
            float exacthours = (float)(hours  + (minutes / 60.0) + (seconds / 3600.0));
            float kmPerHour = kiloMeters / exacthours;
            float milesperhour = (float)(kmPerHour / 1.609);
            Console.WriteLine(meterPerSec);
            Console.WriteLine(kmPerHour);
            Console.WriteLine(milesperhour);
        }
    }
}
