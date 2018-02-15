using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BPM_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            var bpm = int.Parse(Console.ReadLine());
            var beats = int.Parse(Console.ReadLine());
            double result = beats / 4.0;
            var bar = Math.Round(result, 1);
            double bpsec = bpm / 60.0;
            double timel = beats / bpsec;
            double timelength = Math.Truncate(timel);
            var hourstemp = timelength / 60;
            var hours = Math.Truncate(hourstemp);
            var minutes = timelength % 60;

            Console.WriteLine("{0} bars - {1}m {2}s", bar, hours, minutes);
        }
    }
}
