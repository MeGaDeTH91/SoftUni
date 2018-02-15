using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Back_in_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());

            minutes = minutes + 30;
            if (minutes >= 60)
            {
                minutes = minutes - 60;
                hours++;
                
            }
            if (hours >= 24)
            {
                hours = hours - 24;
            }
            Console.WriteLine("{0}:{1:D2}", hours, minutes);
        }
    }
}
