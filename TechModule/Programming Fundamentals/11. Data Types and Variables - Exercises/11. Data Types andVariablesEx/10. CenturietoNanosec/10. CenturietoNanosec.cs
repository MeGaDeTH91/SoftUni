using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _10.CenturietoNanosec
{
    class Program
    {
        static void Main(string[] args)
        {
            byte centuries = byte.Parse(Console.ReadLine());
            uint years = (uint)(centuries * 100);
            uint days = (uint)(years * 365.2422);
            uint hours = days * 24;
            ulong minutes = hours * 60;
            ulong seconds = minutes * 60;
            ulong miliseconds = seconds * 1000;
            BigInteger microseconds = miliseconds * 1000;
            BigInteger nanoseconds = (BigInteger)(microseconds * 1000);

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {miliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");


        }
    }
}
