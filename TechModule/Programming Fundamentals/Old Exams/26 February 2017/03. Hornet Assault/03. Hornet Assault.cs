using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Hornet_Comm
{
    class Privates
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
    class Broadcasts
    {
        public string Message { get; set; }
        public string Frequency { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<long> beeHives = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();
            long initialBees = beeHives.Count;
            List<long> hornets = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();
            long initialHorns = hornets.Count;
            List<long> survivors = new List<long>();
            long takenHives = 0;
            long sum = 0;
            long beesLeft = 0;

            for (int i = 0; i < initialBees; i++)
            {
                sum = hornets.Sum();
                if (sum > beeHives[i])
                {
                    takenHives++;
                }
                else
                {
                    beesLeft = beeHives[i] - sum;
                    if (beesLeft != 0)
                    {
                        survivors.Add(beesLeft);
                    }
                    if(hornets.Count > 0)
                    {
                        hornets.RemoveAt(0);
                    }  
                }
            }
            if (survivors.Count> 0)
            {
                Console.WriteLine(string.Join(" ", survivors));
            }
            else if(hornets.Count> 0)
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}
