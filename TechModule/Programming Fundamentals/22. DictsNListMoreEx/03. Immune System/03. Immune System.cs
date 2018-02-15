using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Immune_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialHealth = int.Parse(Console.ReadLine());
            string virus = Console.ReadLine();
            var timeToDefeat = 0;
            var extraDivider = 1;
            List<string> defeatedViruses = new List<string>();
            int currHealth = initialHealth;
            while (virus != "end")
            {
                var virusStr = virus.ToArray();
                var sum = 0;
                for (int i = 0; i < virusStr.Length; i++)
                {
                    sum += virusStr[i];
                }
                sum /= 3;
                foreach (var item in defeatedViruses)
                {
                    if (virus == item)
                    {
                        extraDivider = 3;
                        break;
                    }
                    else
                    {
                        extraDivider = 1;
                    }
                }
                timeToDefeat = sum * virusStr.Length / extraDivider;
                var minutes = timeToDefeat / 60;
                var seconds = timeToDefeat % 60;
                if (currHealth - timeToDefeat < 0)
                {
                    Console.WriteLine("Virus {0}: {1} => {2} seconds", virus, sum, timeToDefeat);
                    Console.WriteLine("Immune System Defeated.");
                    return;
                }
                else
                {
                    currHealth = currHealth - timeToDefeat;
                    defeatedViruses.Add(virus);
                    Console.WriteLine("Virus {0}: {1} => {2} seconds", virus, sum, timeToDefeat);
                    Console.WriteLine("{0} defeated in {1}m {2}s.", virus, minutes, seconds);
                    Console.WriteLine("Remaining health: {0}", currHealth);
                    currHealth = currHealth * 12 / 10;
                }
                if (currHealth > initialHealth)
                {
                    currHealth = initialHealth;
                }
                virus = Console.ReadLine();
            }
            Console.WriteLine("Final Health: {0}", currHealth);
        }
    }
}
